using Framework.Enum;
using Framework.State;
using Lightsaber.Manager;
using Framework.Extension;

namespace Framework.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        #region Events



        #endregion Events

        #region Variables

        private StateManager _stateManager;

		#endregion Variables

		#region Properties

		private StateManager StateManager { get => _stateManager; set => _stateManager = value; }

		#endregion Properties

		#region Awake - Start

		protected override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            Initialize();
        }

        #endregion Awake - Start

        #region Functions

        public void Initialize()
        {
            OnGameStarts();
        }

        public void OnGameStarts()
		{
            StateManager = new StateManager();
            StateManager.Initialize();

            StateManager.SwitchState(StateType.Game);
        }

        #endregion Functions
    }
}