using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSP.Localization;
using UnityEngine;
using KSP;

namespace AntiSubmarineWeapon
{
    public class FlagWire : PartModule
    {
        //保存的数据
        [KSPField(isPersistant = true)]
        public float speed = 12;
        [KSPField(isPersistant = true)]
        public float scale = 0.09f;
        [KSPField(isPersistant = true)]
        public bool showFlag = true;
        [KSPField(isPersistant = true)]
        public float rad;
        [KSPField(isPersistant = true)]
        public string mainBody;
        [KSPField(isPersistant = true)]
        //间距,旗子宽度为0.64m
        public float space;
        //以下数据不要传值
        [KSPField(isPersistant = true)]
        public Vector3 objLocalScale;
        [KSPField(isPersistant = true)]
        public Vector3 objLocalEulerAngles;
        [KSPField(isPersistant = true)]
        private float randomNumber = 0.0f;
        //------------------------------------------------

        //旗子宽度为0.64m
        private readonly float flagFidth = 0.64f;
        private Transform child = null;
        private Transform flags = null;
        private bool isCreate = false;
        private bool doOnce = true;

        //世界坐标
        private Vector3 startPos;
        private Vector3 endPos;
        private GameObject baseFlag;
        private Dictionary<int, string> findName;
        private Texture2D[] mainTex;
        private Material[] mats;
        private GameObject temp;
        private GameObject father;
        private double count = 0.0;

        [KSPEvent(guiActive = true, guiActiveEditor = true, guiName = "Open/Close Flags", active = true)]
        public void SwitchFlag()
        {
            this.showFlag = !showFlag;
            ShowOrHideFlags();
        }

        private void FindChild(Transform father, string name)
        {
            child = this.transform.Find("model/Sphere/" + name);
        }

        private void FindChildFlags(Transform father)
        {
            if (father.transform.name == "flags")
            {
                flags = father;
            }
            for (int i = 0; i < father.transform.childCount; i++)
            {
                FindChildFlags(father.transform.GetChild(i));
            }
        }

        private void CreateMesh(Vector3 startPos, Vector3 endPos, float rad)
        {
            if (child != null)
            {
                child.transform.parent = temp.transform;
                float length = (startPos - endPos).magnitude;
                child.transform.localEulerAngles = Vector3.zero;
                child.transform.LookAt(endPos);
                child.transform.parent = father.transform;
                child.transform.localScale = new Vector3(rad, rad, length * 20);
                flags.transform.localScale = new Vector3(1.0f / rad, 1.0f / rad, 1.0f / (length * 20));
                ShowOrHideFlags(length);
            }
        }

        private void RandomFlag(int i)
        {
            if (flags != null)
            {
                //0-25
                int number = (int)(((Mathf.Cos(randomNumber + i * 123) + 1) / 2.0) * 26);
                if (mats != null)
                {
                    Debug.Log(flags.transform.GetChild(i).Find("box/flagTransform").gameObject.name);

                    flags.transform.GetChild(i).Find("box/flagTransform").GetComponent<MeshRenderer>().material = mats[number];
                    flags.transform.GetChild(i).Find("box/flagTransform2").GetComponent<MeshRenderer>().material = mats[number];
                    flags.transform.GetChild(i).Find("box/flagMiddle").GetComponent<MeshRenderer>().material = mats[number];
                    flags.transform.GetChild(i).Find("box/flagMiddle2").GetComponent<MeshRenderer>().material = mats[number];

                }
            }
        }

        private void ShowOrHideFlags(float length = 0.0f)
        {
            if (showFlag)
            {
                flags.gameObject.SetActive(true);
                float flagLength = flagFidth + space;
                int flagNumber = 0;
                if (objLocalScale.z != 0.0)
                {
                    flags.parent.Find("Cylinder").GetComponent<MeshRenderer>().material.SetTextureScale("_MainTex", new Vector2(1, objLocalScale.z));
                    flagNumber = (int)((objLocalScale.z / 20.0f) / flagLength);
                }
                else
                {
                    flags.parent.Find("Cylinder").GetComponent<MeshRenderer>().material.SetTextureScale("_MainTex", new Vector2(1, length * 20));
                    flagNumber = (int)(length / flagLength);
                }
                baseFlag = flags.Find("flag").gameObject;
                if (flagNumber == 0)
                {
                    flags.gameObject.SetActive(false);
                }
                else
                {
                    flags.gameObject.SetActive(true);
                    baseFlag.transform.localPosition = new Vector3(0, 0, space * 10);
                    for (int i = 0; i < flags.transform.childCount; i++)
                    {
                        if (flags.transform.GetChild(i).name == "flag(clone)")
                        {
                            Destroy(flags.transform.GetChild(i).gameObject);
                        }
                    }
                    RandomFlag(0);
                    for (int i = 0; i < (flagNumber - 1); i++)
                    {
                        GameObject temp = Instantiate(baseFlag.gameObject, flags.transform);
                        temp.name = "flag(clone)";
                        temp.transform.localEulerAngles = new Vector3(0, 0, 0);
                        temp.transform.localScale = new Vector3(1, 1, 1);
                        temp.transform.localPosition = new Vector3(0, 0, space * 10 + flagLength * (i + 1) * 10);
                        int a = i + 1;
                        int number = (int)(((Mathf.Cos(randomNumber + a * 123) + 1) / 2.0) * 26);
                        temp.transform.Find("box/flagTransform").GetComponent<MeshRenderer>().material = mats[number];
                        temp.transform.Find("box/flagTransform2").GetComponent<MeshRenderer>().material = mats[number];
                        temp.transform.Find("box/flagMiddle").GetComponent<MeshRenderer>().material = mats[number];
                        temp.transform.Find("box/flagMiddle2").GetComponent<MeshRenderer>().material = mats[number];
                    }
                }
            }
            else
            {
                flags.gameObject.SetActive(false);
                if (objLocalScale.z != 0.0)
                {
                    flags.parent.Find("Cylinder").GetComponent<MeshRenderer>().material.SetTextureScale("_MainTex", new Vector2(1, objLocalScale.z));
                }
                else
                {
                    flags.parent.Find("Cylinder").GetComponent<MeshRenderer>().material.SetTextureScale("_MainTex", new Vector2(1, length * 20));
                }
            }
        }

        private void Wave(Vector3[] flag, MeshFilter mesh, float offset)
        {
            for (int i = 0; i < flag.Length; i++)
            {
                offset = Mathf.Abs(offset);
                float dis = Mathf.Cos(offset) / 2.0f;
                if (flag[i].x == 0.5f) continue;
                flag[i].z += Mathf.Sin((float)(Planetarium.GetUniversalTime() + offset) * (speed * (1 + dis)) + flag[i].x + 5 * (flag[i].y + flag[i].x));
                flag[i].z *= (scale * (1 + dis));
            }
            mesh.mesh.vertices = flag;
        }

        private void WaveT(Vector3[] flag, MeshFilter mesh, float offset)
        {
            for (int i = 0; i < flag.Length; i++)
            {
                offset = Mathf.Abs(offset);
                float dis = Mathf.Cos(offset) / 2.0f;
                if (flag[i].x == 0.5f) continue;
                flag[i].z -= Mathf.Sin((float)(Planetarium.GetUniversalTime() + offset) * (speed * (1 + dis)) + flag[i].x + 5 * (-flag[i].y + flag[i].x));
                flag[i].z *= (scale * (1 + dis));
            }
            mesh.mesh.vertices = flag;
        }

        private void WaveFlag(GameObject flag)
        {
            Wave(flag.transform.Find("box/flagTransform").GetComponent<MeshFilter>().mesh.vertices, flag.transform.Find("box/flagTransform").GetComponent<MeshFilter>(), flag.transform.Find("box").GetInstanceID());
            Wave(flag.transform.Find("box/flagMiddle").GetComponent<MeshFilter>().mesh.vertices, flag.transform.Find("box/flagMiddle").GetComponent<MeshFilter>(), flag.transform.Find("box").GetInstanceID());
            Wave(flag.transform.Find("box/flagTransform2").GetComponent<MeshFilter>().mesh.vertices, flag.transform.Find("box/flagTransform2").GetComponent<MeshFilter>(), flag.transform.Find("box").GetInstanceID());
            WaveT(flag.transform.Find("box/flagMiddle2").GetComponent<MeshFilter>().mesh.vertices, flag.transform.Find("box/flagMiddle2").GetComponent<MeshFilter>(), flag.transform.Find("box").GetInstanceID());
        }

        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            if (HighLogic.LoadedSceneIsEditor || HighLogic.LoadedSceneIsFlight)
            {
                FindChild(this.transform, mainBody);
                if (child != null)
                {
                    FindChildFlags(child);
                    child.transform.Find("Cylinder").GetComponent<CapsuleCollider>().enabled = false;
                    if (flags != null)
                    {
                        flags.gameObject.SetActive(false);
                        flags.Find("flag").GetChild(0).GetComponent<BoxCollider>().enabled = false;
                        findName = new Dictionary<int, string>();
                        findName.Add(0, "A"); findName.Add(1, "B"); findName.Add(2, "C"); findName.Add(3, "D"); findName.Add(4, "E");
                        findName.Add(5, "F"); findName.Add(6, "G"); findName.Add(7, "H"); findName.Add(8, "I"); findName.Add(9, "J");
                        findName.Add(10, "K"); findName.Add(11, "L"); findName.Add(12, "M"); findName.Add(13, "N"); findName.Add(14, "O");
                        findName.Add(15, "P"); findName.Add(16, "Q"); findName.Add(17, "R"); findName.Add(18, "S"); findName.Add(19, "T");
                        findName.Add(20, "U"); findName.Add(21, "V"); findName.Add(22, "W"); findName.Add(23, "X"); findName.Add(24, "Y");
                        findName.Add(25, "Z");
                        mainTex = new Texture2D[26];
                        mats = new Material[26];
                        for (int i = 0; i < 26; i++)
                        {
                            mainTex[i] = GameDatabase.Instance.GetTexture("NAS/Textures/SignalFlags/Alphabet/" + findName[i], false);
                            mats[i] = new Material(Shader.Find("KSP/Alpha/Translucent"));
                            mats[i].SetTexture("_MainTex", mainTex[i]);
                        }
                    }
                    if (HighLogic.LoadedSceneIsEditor)
                    {
                        FlagWireController.flagwireList.Add(this);
                        father = child.transform.parent.gameObject;
                        temp = new GameObject("temp");
                        temp.transform.position = Vector3.zero;
                        temp.transform.eulerAngles = Vector3.zero;
                        temp.transform.localScale = new Vector3(1, 1, 1);
                        if (randomNumber == 0.0f)
                            randomNumber = Time.time;
                    }
                    if (HighLogic.LoadedSceneIsFlight)
                        FlagWireController.flagwireList.Clear();
                }
                else
                {
                    Debug.Log("[NAS-Flag] Init failed!");
                }
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (HighLogic.LoadedSceneIsFlight)
            {
                if (doOnce)
                {
                    if (child != null)
                    {
                        child.transform.localEulerAngles = objLocalEulerAngles;
                        child.transform.localScale = objLocalScale;
                        flags.transform.localScale = new Vector3(1.0f / objLocalScale.x, 1.0f / objLocalScale.y, 1.0f / objLocalScale.z);
                        ShowOrHideFlags();
                        var collider = child.transform.Find("Cylinder").GetComponent<CapsuleCollider>();
                        collider.enabled = true;
                    }
                    else
                    {
                        Debug.Log("[NAS-Flag] No flag's wire!");
                    }
                    doOnce = false;
                }
                for (int i = 0; i < flags.transform.childCount; i++)
                {
                    if (flags.transform.GetChild(i).name.Contains("flag"))
                        WaveFlag(flags.transform.GetChild(i).gameObject);
                }
            }
        }

        public void EditorUpdate()
        {
            base.OnUpdate();
            if (HighLogic.LoadedSceneIsEditor)
            {
                count++;
                if (part.parent != null)
                {
                    if (doOnce)
                    {

                        if (!isCreate)
                        {
                            startPos = child.transform.position;
                            Debug.Log("[NAS-Flag] start: " + startPos);
                            isCreate = true;
                        }
                        else
                        {
                            if (count < 10)
                            {
                                if (child != null)
                                {
                                    child.transform.localEulerAngles = objLocalEulerAngles;
                                    child.transform.localScale = objLocalScale;
                                    flags.transform.localScale = new Vector3(1.0f / objLocalScale.x, 1.0f / objLocalScale.y, 1.0f / objLocalScale.z);
                                    ShowOrHideFlags();
                                    var collider = child.transform.Find("Cylinder").GetComponent<CapsuleCollider>();
                                    collider.enabled = true;
                                }
                                else
                                {
                                    Debug.Log("[NAS-Flag] No flag's wire!");
                                }
                                doOnce = false;
                                return;
                            }
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hitInfo;
                            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.layer != 15 && hitInfo.collider.gameObject.name != "ShadowPlane")
                            {
                                endPos = hitInfo.point;
                                CreateMesh(startPos, endPos, rad);
                                if (Input.GetMouseButtonDown(1))
                                {
                                    var collider = child.transform.Find("Cylinder").GetComponent<CapsuleCollider>();
                                    collider.enabled = true;
                                    objLocalScale = child.transform.localScale;
                                    objLocalEulerAngles = child.transform.localEulerAngles;
                                    Debug.Log("[NAS-Flag] end: " + hitInfo.point);
                                    isCreate = false;
                                    doOnce = false;
                                    if (FlagWireController.flagwireList.Count != 0)
                                        FlagWireController.flagwireList = new List<FlagWire>();
                                }
                            }
                            else
                            {
                                //动态修改网格
                                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 5);
                                CreateMesh(startPos, endPos, rad);
                            }
                        }
                    }
                }
            }
        }
    }
}
