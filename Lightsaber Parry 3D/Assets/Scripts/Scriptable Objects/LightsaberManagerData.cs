using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LightsaberManagerScriptableObject", order = 1)]
    public class LightsaberManagerData : ScriptableObject
    {
        #region Variables

        public float rotateAngle;
        public float rotateSpeed;

        #endregion Variables

        #region Properties



        #endregion Properties
    }
}