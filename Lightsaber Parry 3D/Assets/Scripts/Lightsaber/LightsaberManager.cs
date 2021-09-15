using Framework.Data;
using System;
using UnityEngine;

namespace Lightsaber.Manager
{
    public class LightsaberManager : MonoBehaviour
    {
        #region Events

        public Action<bool> OnDotProductUpdated;

        #endregion Events

        #region Variables

        [SerializeField] private LightsaberController _lightsaberControllerBack;
        [SerializeField] private LightsaberController _lightsaberControllerFront;

        [SerializeField] private ParticleSystem _lightsaberCollideParticle;
        
        private LightsaberManagerData _lightsaberManagerScriptableObject;

		#endregion Variables

		#region Properties

        public LightsaberController LightsaberControllerBack { get => _lightsaberControllerBack; set => _lightsaberControllerBack = value; }
		public LightsaberController LightsaberControllerFront { get => _lightsaberControllerFront; set => _lightsaberControllerFront = value; }
		
        private ParticleSystem LightsaberCollideParticle { get => _lightsaberCollideParticle; set => _lightsaberCollideParticle = value; }
		
        private LightsaberManagerData LightsaberManagerScriptableObject { get => _lightsaberManagerScriptableObject; set => _lightsaberManagerScriptableObject = value; }

		#endregion Properties

		#region Functions

		public void Initialize()
        {
            LightsaberManagerScriptableObject = Resources.Load("ScriptableObjects/LightsaberManagerScriptableObject") as LightsaberManagerData;

            LightsaberControllerBack.Initialize(LightsaberManagerScriptableObject.rotateAngle, LightsaberManagerScriptableObject.rotateSpeed);
            LightsaberControllerFront.Initialize(LightsaberManagerScriptableObject.rotateAngle, LightsaberManagerScriptableObject.rotateSpeed);

            SubscribeEvents();
        }

        public void SubscribeEvents()
        {
            LightsaberControllerBack.LightsaberCollisionController.OnLightsabersCollide += LightsaberControllerBack.LightsaberRotate.DisableRotation;
            LightsaberControllerFront.LightsaberCollisionController.OnLightsabersCollide += LightsaberControllerFront.LightsaberRotate.DisableRotation;
        }

        public void UnSubscribeEvents()
        {
            LightsaberControllerBack.LightsaberCollisionController.OnLightsabersCollide -= LightsaberControllerBack.LightsaberRotate.DisableRotation;
            LightsaberControllerFront.LightsaberCollisionController.OnLightsabersCollide -= LightsaberControllerFront.LightsaberRotate.DisableRotation;
        }

        public void CheckIfLightsabersWillCollide(float sliderValue)
		{
            LightsaberControllerBack.DotProductHelper.transform.rotation = LightsaberControllerBack.transform.rotation;
            LightsaberControllerFront.DotProductHelper.transform.rotation = LightsaberControllerFront.transform.rotation;
            
            LightsaberControllerBack.DotProductHelper.transform.rotation = new Quaternion(0, Mathf.Sin(Mathf.PI / 180f * 22.5f), 0, Mathf.Cos(Mathf.PI / 180f * 22.5f)) * LightsaberControllerBack.DotProductHelper.transform.rotation;
            LightsaberControllerFront.DotProductHelper.transform.rotation = new Quaternion(0, Mathf.Sin(Mathf.PI / 180f * 22.5f), 0, Mathf.Cos(Mathf.PI / 180f * 22.5f)) * LightsaberControllerFront.DotProductHelper.transform.rotation;
            
            float dotProduct = Vector3.Dot(LightsaberControllerBack.DotProductHelper.transform.up * 2.4f, LightsaberControllerFront.DotProductHelper.transform.up * 2.4f);

            OnDotProductUpdated?.Invoke(dotProduct < 1f ? true : false);
        }

        #region LightsaberController Functions

        public void SetLightsaberBackRotation(float value)
        {
            LightsaberControllerBack.SetLightsaberRotation(value);
        }

        public void SetLightsaberFrontRotation(float value)
        {
            LightsaberControllerFront.SetLightsaberRotation(-value);
        }

        public void EnableLightsaberRotateBack()
		{
            LightsaberControllerBack.EnableLightsaberRotate();
		}

        public void EnableLightsaberRotateFront()
        {
            LightsaberControllerFront.EnableLightsaberRotate();
        }

        public void ResetLightsaberBack()
		{
            LightsaberControllerBack.ResetLightsaber();
		}

        public void ResetLightsaberFront()
        {
            LightsaberControllerFront.ResetLightsaber();
        }

        #endregion LightsaberController Functions

        #endregion Functions
    }
}