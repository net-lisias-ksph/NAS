using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;

namespace AntiSubmarineWeapon
{
    class FlagWave : PartModule
    {
        [KSPField]
        public float speed = 12;
        [KSPField]
        public float scale = 0.09f;

        private Transform flag1;
        private Transform flag2;
        private Transform flagm1;
        private Transform flagm2;
        private Vector3[] flagVertex1;
        private Vector3[] flagVertex2;
        private Vector3[] flagmVertex1;
        private Vector3[] flagmVertex2;

        public void PrintChild(Transform father)
        {
            if (father.transform.name == "flagTransform")
            {
                this.flag1 = father;
            }
            if (father.transform.name == "flagTransform2")
            {
                this.flag2 = father;
            }
            if (father.transform.name == "flagMiddle")
            {
                this.flagm1 = father;
            }
            if (father.transform.name == "flagMiddle2")
            {
                this.flagm2 = father;
            }
            if (father.transform.childCount == 0)
            {
                return;
            }
            for (int i = 0; i < father.transform.childCount; i++)
            {
                PrintChild(father.transform.GetChild(i));
            }
        }

        private void Wave(Vector3[] flag, MeshFilter mesh, float timeOffet, float offset = 0)
        {
            for (int i = 0; i < flag.Length; i++)
            {
                timeOffet = Mathf.Abs(timeOffet);
                offset = Mathf.Abs(offset);
                float dis = Mathf.Cos(offset) / 2.0f;
                if (flag[i].x == 0.5f) continue;
                flag[i].z += Mathf.Sin((float)(Planetarium.GetUniversalTime() + offset + timeOffet) * (speed * (1 + dis)) + flag[i].x + 5 * (flag[i].y + flag[i].x));
                flag[i].z *= (scale * (1 + dis));
            }
            mesh.mesh.vertices = flag;
        }

        private void WaveT(Vector3[] flag, MeshFilter mesh, float timeOffet, float offset = 0)
        {
            for (int i = 0; i < flag.Length; i++)
            {
                timeOffet = Mathf.Abs(timeOffet);
                offset = Mathf.Abs(offset);
                float dis = Mathf.Cos(offset) / 2.0f;
                if (flag[i].x == 0.5f) continue;
                flag[i].z -= Mathf.Sin((float)(Planetarium.GetUniversalTime() + offset + timeOffet) * (speed * (1 + dis)) + flag[i].x + 5 * (-flag[i].y + flag[i].x));
                flag[i].z *= (scale * (1 + dis));
            }
            mesh.mesh.vertices = flag;
        }
        private float offset;
        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            if (HighLogic.LoadedSceneIsFlight)
            {
                offset = UnityEngine.Random.Range(1.0f, 1000001.0f);
                PrintChild(this.transform);
                flagVertex1 = flag1.GetComponent<MeshFilter>().mesh.vertices;
                flagVertex2 = flag2.GetComponent<MeshFilter>().mesh.vertices;
                flagmVertex1 = flagm1.GetComponent<MeshFilter>().mesh.vertices;
                flagmVertex2 = flagm2.GetComponent<MeshFilter>().mesh.vertices;
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (HighLogic.LoadedSceneIsFlight)
            {
                Wave(flagVertex1, flag1.GetComponent<MeshFilter>(), 0, (int)offset);
                Wave(flagmVertex1, flagm1.GetComponent<MeshFilter>(), 0, (int)offset);
                Wave(flagVertex2, flag2.GetComponent<MeshFilter>(), 0, (int)offset);
                WaveT(flagmVertex2, flagm2.GetComponent<MeshFilter>(), 0, (int)offset);
            }
        }
    }
}
