using UnityEngine;
using Framework.Enum;

namespace Framework.State
{
    public class StateManager
    {
        #region Variables

        private BaseState _currentState;

        private MenuState _menuState;
        private GameState _gameState;

        #endregion Variables

        #region Properties

        private BaseState CurrentState { get => _currentState; set => _currentState = value; }
        private MenuState MenuState { get => _menuState; set => _menuState = value; }
        private GameState GameState { get => _gameState; set => _gameState = value; }

        #endregion Properties

        #region Functions

        public void Initialize()
        {
            MenuState = new MenuState();
            GameState = new GameState();
        }

        public void SwitchState(StateType stateType)
		{
            if (CurrentState?.stateType == stateType)
			{
                Debug.Log("Already in " + CurrentState);
                return;
            }

            CurrentState?.Terminate();

			switch (stateType)
			{
				case StateType.Menu:
                    CurrentState = MenuState;
					break;
				case StateType.Game:
                    CurrentState = GameState;
					break;
				default:
					break;
			}

            CurrentState?.Initialize();
		}

        #endregion Functions
    }
}