using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace AntiSubmarineWeapon
{
    public class AimingLine : PartModule
    {
        [UI_FloatRange(scene = UI_Scene.Flight, maxValue = 200f, minValue = 1f)]
        [KSPField(isPersistant = true, guiActive = true, guiActiveEditor = false, guiName = "Aiming Line Length")]
        public float Length = 2.0f;
        [UI_FloatRange(scene = UI_Scene.Flight, maxValue = 20f, minValue = 1f)]
        [KSPField(isPersistant = true, guiActive = true, guiActiveEditor = false, guiName = "Aiming Line Width")]
        public float Width = 10f;
        [KSPField(isPersistant = true)]
        public float maxDropAltitude;
        [KSPField(isPersistant = true)]
        public float maxDropSpeed;
        [KSPField(isPersistant = true)]
        public bool useMouse = true;

        private GameObject renderLine;
        private GameObject renderLineP1;
        private GameObject renderLineP2;
        private LineRenderer vector;
        private Color color;
        private Material lineMat = null;
        private bool flag = false;

        private void ResetTransfrom(ref GameObject temp)
        {
            temp.transform.localPosition = Vector3.zero;
            temp.transform.localEulerAngles = Vector3.zero;
            temp.transform.localScale = Vector3.one;
        }

        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            if (HighLogic.LoadedSceneIsFlight)
            {
                if (this.transform.Find("model").GetChild(0) != null)
                {
                    GameObject temp = new GameObject("renderLine");
                    temp.transform.parent = this.transform.Find("model").GetChild(0);
                    ResetTransfrom(ref temp);
                    this.renderLine = temp;
                    if (renderLine != null)
                    {
                        GameObject p1 = new GameObject("p1");
                        GameObject p2 = new GameObject("p2");
                        p1.transform.parent = renderLine.transform;
                        p2.transform.parent = renderLine.transform;
                        ResetTransfrom(ref p1);
                        ResetTransfrom(ref p2);
                        this.renderLineP1 = p1;
                        this.renderLineP2 = p2;
                    }
                }
                else
                {
                    Debug.LogError("[NAS-AimingLine] Args wrong!");
                }
                vector = this.renderLine.GetComponent<LineRenderer>();
                color = Color.green;
                color.a = 1.0f;
                lineMat = new Material(Shader.Find("KSP/Particles/Alpha Blended"));

                if (vector == null)
                {
                    vector = this.renderLine.gameObject.AddComponent<LineRenderer>();
                }
                if (this.renderLineP1 == null && this.renderLineP2 == null)
                {
                    Debug.LogError("args wrong!");
                    return;
                }
                else
                {
                    UpdataPos();
                    ChildAddTag(this.transform.Find("model").GetChild(0));
                }
            }
        }

        private void UpdataPos()
        {
            if (vessel.altitude < this.maxDropAltitude
                && vessel.speed < this.maxDropSpeed
                && vessel.Parts.Count > 1
                && FlightGlobals.fetch.activeVessel == this.vessel
                && (useMouse ? RayTest() : KeyDown(KeyCode.L)))
            {
                var colorTemp = this.color;
                colorTemp.a = color.a / 2;
                lineMat.SetColor("_TintColor", colorTemp);
                vector.material = this.lineMat;
                vector.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                vector.receiveShadows = false;
                vector.startWidth = Width / 100;
                vector.endWidth = Width / 100;
                vector.positionCount = 2;
                this.renderLineP2.transform.localPosition = new Vector3(0, 0, 1);
                var p1 = this.renderLineP1.transform.position - vessel.upAxis * (vessel.altitude - 0.3f);
                var p2 = this.renderLineP2.transform.position - vessel.upAxis * (vessel.altitude - 0.3f);
                p2 = p1 + Vector3.ProjectOnPlane(p2 - p1, vessel.upAxis).normalized * Length;
                vector.SetPosition(0, p1);
                vector.SetPosition(1, p2);
                vector.useWorldSpace = true;
                vector.enabled = true;
            }
            else
            {
                vector.enabled = false;
                flag = false;
            }
        }

        private bool KeyDown(KeyCode key)
        {
            if (!flag)
            {
                if (Input.GetKeyDown(key))
                {
                    flag = !flag;
                }
            }
            else
            {
                if (Input.GetKeyDown(key))
                {
                    flag = !flag;
                }
            }
            return flag;
        }

        private bool RayTest()
        {
            var baseObj = this.transform.Find("model").GetChild(0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.name.Contains("AimingLineTag"))
            {
                return true;
            }

            return false;
        }

        private void ChildAddTag(Transform father)
        {
            if (father.transform.GetComponent<MeshCollider>() != null
                || father.transform.GetComponent<BoxCollider>() != null
                || father.transform.GetComponent<CapsuleCollider>() != null)
            {
                father.gameObject.name = father.gameObject.name + "-AimingLineTag";
            }

            if (father.transform.childCount == 0)
            {
                return;
            }
            for (int i = 0; i < father.transform.childCount; i++)
            {
                ChildAddTag(father.transform.GetChild(i));
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (HighLogic.LoadedSceneIsFlight)
            {
                UpdataPos();
            }
        }
    }
}
