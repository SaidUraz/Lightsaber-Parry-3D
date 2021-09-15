using System;
using UnityEngine;
using UnityEngine.UI;

namespace Framework.UI
{
    public class SliderCanvasController : BaseCanvasController
    {
        #region Events

        public Action<float> OnSliderUpValueChanged;
        public Action<float> OnSliderDownValueChanged;

        #endregion Events

        #region Variables

        [SerializeField] private Slider _sliderUp;
        [SerializeField] private Slider _sliderDown;

        #endregion Variables

        #region Properties

        private Slider SliderUp { get => _sliderUp; }
        private Slider SliderDown { get => _sliderDown; }

        #endregion Properties

        #region Functions

        public override void Initialize()
        {
            base.Initialize();

            SliderUp.onValueChanged.AddListener(delegate { OnSliderUpValueChanged?.Invoke(SliderUp.value); });
            SliderDown.onValueChanged.AddListener(delegate { OnSliderDownValueChanged?.Invoke(SliderDown.value); });

            SubscribeEvents();
        }

        public override void SubscribeEvents()
        {
            base.SubscribeEvents();
        }

        public override void UnSubscribeEvents()
        {
            base.UnSubscribeEvents();
        }

        public void ResetSliders()
		{
            SliderUp.value = 0;
            SliderDown.value = 0;
		}

        #endregion Functions
    }
}