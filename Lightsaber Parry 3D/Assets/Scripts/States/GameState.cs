using UnityEngine;
using Framework.Pool;
using Lightsaber.Manager;

namespace Framework.State
{
    public class GameState : BaseState
    {
		#region Variables

		private GameObject _canvasManagerGameObject;
		private GameObject _lightsaberManagerGameObject;

		private PoolManager _poolManager;
        private CanvasManager _canvasManager;
        private LightsaberManager _lightsaberManager;

		#endregion Variables

		#region Properties

		private GameObject CanvasManagerGameObject { get => _canvasManagerGameObject; set => _canvasManagerGameObject = value; }
		private GameObject LightsaberManagerGameObject { get => _lightsaberManagerGameObject; set => _lightsaberManagerGameObject = value; }
		
		private PoolManager PoolManager { get => _poolManager; set => _poolManager = value; }
		private CanvasManager CanvasManager { get => _canvasManager; set => _canvasManager = value; }
		private LightsaberManager LightsaberManager { get => _lightsaberManager; set => _lightsaberManager = value; }

		#endregion Properties

		#region Functions

		public override void Initialize()
		{
			base.Initialize();

			CanvasManagerGameObject = Resources.Load("Prefabs/Canvas_Manager") as GameObject;
			LightsaberManagerGameObject = Resources.Load("Prefabs/Lightsaber_Manager") as GameObject;

			PoolManager = new PoolManager();
			CanvasManager = GameObject.Instantiate(CanvasManagerGameObject, null).GetComponent<CanvasManager>();
			LightsaberManager = GameObject.Instantiate(LightsaberManagerGameObject, null).GetComponent<LightsaberManager>();

			CanvasManager.Initialize();
			LightsaberManager.Initialize();

			SubscribeEvents();
		}

		public override void Terminate()
		{
			base.Terminate();

			UnSubscribeEvents();
		}

		public void SubscribeEvents()
		{
			CanvasManager.ButtonCanvasController.OnResetButtonClick += CanvasManager.SliderCanvasController.ResetSliders;

			CanvasManager.SliderCanvasController.OnSliderUpValueChanged += LightsaberManager.SetLightsaberBackRotation;
			CanvasManager.SliderCanvasController.OnSliderDownValueChanged += LightsaberManager.SetLightsaberFrontRotation;

			CanvasManager.SliderCanvasController.OnSliderUpValueChanged += LightsaberManager.CheckIfLightsabersWillCollide;
			CanvasManager.SliderCanvasController.OnSliderDownValueChanged += LightsaberManager.CheckIfLightsabersWillCollide;

			CanvasManager.ButtonCanvasController.OnSimulateButtonClick += LightsaberManager.EnableLightsaberRotateBack;
			CanvasManager.ButtonCanvasController.OnSimulateButtonClick += LightsaberManager.EnableLightsaberRotateFront;

			CanvasManager.ButtonCanvasController.OnResetButtonClick += LightsaberManager.ResetLightsaberBack;
			CanvasManager.ButtonCanvasController.OnResetButtonClick += LightsaberManager.ResetLightsaberFront;

			LightsaberManager.OnDotProductUpdated += CanvasManager.FeedbackCanvasController.UpdateCollideMessageText;
			
			LightsaberManager.LightsaberControllerBack.LightsaberCollisionController.OnLightsabersCollideWithVector += PoolManager.ActivateCollideParticlePoolItem;
			LightsaberManager.LightsaberControllerFront.LightsaberCollisionController.OnLightsabersCollideWithVector += PoolManager.ActivateCollideParticlePoolItem;
		}

		public void UnSubscribeEvents()
		{
			CanvasManager.ButtonCanvasController.OnResetButtonClick -= CanvasManager.SliderCanvasController.ResetSliders;

			CanvasManager.SliderCanvasController.OnSliderUpValueChanged -= LightsaberManager.SetLightsaberBackRotation;
			CanvasManager.SliderCanvasController.OnSliderDownValueChanged -= LightsaberManager.SetLightsaberFrontRotation;

			CanvasManager.SliderCanvasController.OnSliderUpValueChanged -= LightsaberManager.CheckIfLightsabersWillCollide;
			CanvasManager.SliderCanvasController.OnSliderDownValueChanged -= LightsaberManager.CheckIfLightsabersWillCollide;

			CanvasManager.ButtonCanvasController.OnSimulateButtonClick -= LightsaberManager.EnableLightsaberRotateBack;
			CanvasManager.ButtonCanvasController.OnSimulateButtonClick -= LightsaberManager.EnableLightsaberRotateFront;

			CanvasManager.ButtonCanvasController.OnResetButtonClick -= LightsaberManager.ResetLightsaberBack;
			CanvasManager.ButtonCanvasController.OnResetButtonClick -= LightsaberManager.ResetLightsaberFront;

			LightsaberManager.OnDotProductUpdated -= CanvasManager.FeedbackCanvasController.UpdateCollideMessageText;

			LightsaberManager.LightsaberControllerBack.LightsaberCollisionController.OnLightsabersCollideWithVector -= PoolManager.ActivateCollideParticlePoolItem;
			LightsaberManager.LightsaberControllerFront.LightsaberCollisionController.OnLightsabersCollideWithVector -= PoolManager.ActivateCollideParticlePoolItem;
		}

		#endregion Functions
	}
}