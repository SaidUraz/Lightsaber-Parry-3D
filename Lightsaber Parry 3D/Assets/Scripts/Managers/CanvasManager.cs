using UnityEngine;
using Framework.UI;

namespace Lightsaber.Manager
{
    public class CanvasManager : MonoBehaviour
	{
        #region Variables

        [SerializeField] private SliderCanvasController _sliderCanvasController;
        [SerializeField] private ButtonCanvasController _buttonCanvasController;
        [SerializeField] private FeedbackCanvasController _feedbackCanvasController;

		#endregion Variables

		#region Properties

		public SliderCanvasController SliderCanvasController { get => _sliderCanvasController; set => _sliderCanvasController = value; }
		public ButtonCanvasController ButtonCanvasController { get => _buttonCanvasController; set => _buttonCanvasController = value; }
		public FeedbackCanvasController FeedbackCanvasController { get => _feedbackCanvasController; set => _feedbackCanvasController = value; }

		#endregion Properties

        #region Functions

        public void Initialize()
        {
            SliderCanvasController.Initialize();
            ButtonCanvasController.Initialize();
            FeedbackCanvasController.Initialize();

            SubscribeEvents();
        }

        public void SubscribeEvents()
        {
            SliderCanvasController.OnSliderDownValueChanged += SliderCanvasController.OnSliderDownValueChanged;
            SliderCanvasController.OnSliderUpValueChanged += SliderCanvasController.OnSliderUpValueChanged;
        }

        public void UnSubscribeEvents()
        {
            SliderCanvasController.OnSliderDownValueChanged -= SliderCanvasController.OnSliderDownValueChanged.Invoke;
            SliderCanvasController.OnSliderUpValueChanged -= SliderCanvasController.OnSliderUpValueChanged.Invoke;
        }

		#endregion Functions
	}
}