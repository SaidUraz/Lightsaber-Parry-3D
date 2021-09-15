using UnityEngine;
using DG.Tweening;

namespace Framework.UI
{
    public class BaseCanvasController : MonoBehaviour
    {
        #region Events



        #endregion Events

        #region Variables

        [SerializeField] private CanvasGroup _canvasGroup;

		#endregion Variables

		#region Properties

		private CanvasGroup CanvasGroup { get => _canvasGroup; set => _canvasGroup = value; }

		#endregion Properties

		#region OnEnable

		void OnEnable()
		{
            CanvasGroup.DOFade(1f, 0.5f);
		}

		#endregion OnEnable

		#region Functions

		public virtual void Initialize()
        {

        }

        public virtual void SubscribeEvents()
        {

        }

        public virtual void UnSubscribeEvents()
        {

        }

        #endregion Functions
    }
}