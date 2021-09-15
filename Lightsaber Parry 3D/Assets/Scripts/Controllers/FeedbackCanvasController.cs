using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

namespace Framework.UI
{
    public class FeedbackCanvasController : BaseCanvasController
    {
        #region Events



        #endregion Events

        #region Variables

        [SerializeField] private TextMeshProUGUI _feedbackText;

		public TextMeshProUGUI FeedbackText { get => _feedbackText; set => _feedbackText = value; }

		#endregion Variables

		#region Properties



		#endregion Properties

		#region Functions

		public override void Initialize()
        {
            base.Initialize();
        }

        public override void SubscribeEvents()
        {
            base.SubscribeEvents();
        }

        public override void UnSubscribeEvents()
        {
            base.UnSubscribeEvents();
        }

        public void UpdateCollideMessageText(bool willCollide)
		{
            string text = "";
            Color color = Color.white;

			if (willCollide)
			{
                text = "Will Collide";
                color = Color.green;
            }
            else
			{
                text = "Won't Collide";
                color = Color.red;
            }

            if (DOTween.IsTweening(FeedbackText))
                DOTween.Kill(FeedbackText);

            FeedbackText.text = text;
            FeedbackText.DOColor(color, 0.5f);
        }

        #endregion Functions
    }
}