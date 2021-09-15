using System;
using UnityEngine;
using UnityEngine.UI;

namespace Framework.UI
{
    public class ButtonCanvasController : BaseCanvasController
    {
        #region Events

        public Action OnResetButtonClick;
        public Action OnSimulateButtonClick;

        #endregion Events

        #region Variables

        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _simulateButton;

		#endregion Variables

		#region Properties

		private Button ResetButton { get => _resetButton; set => _resetButton = value; }
		private Button SimulateButton { get => _simulateButton; set => _simulateButton = value; }

		#endregion Properties

        #region Functions

        public override void Initialize()
        {
            base.Initialize();

            ResetButton.onClick.AddListener(delegate { OnResetButtonClick.Invoke(); });
            SimulateButton.onClick.AddListener(delegate { OnSimulateButtonClick.Invoke(); });
        }

        public override void SubscribeEvents()
        {
            base.SubscribeEvents();
        }

        public override void UnSubscribeEvents()
        {
            base.UnSubscribeEvents();
        }

		#endregion Functions
	}
}