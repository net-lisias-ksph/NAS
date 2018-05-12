using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
namespace AntiSubmarineWeapon
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class FlagWireController : MonoBehaviour
    {
        public static List<FlagWire> flagwireList = new List<FlagWire>();

        public void Update()
        {
            foreach (var temp in flagwireList)
            {
                temp.EditorUpdate();
            }
        }
    }
}
