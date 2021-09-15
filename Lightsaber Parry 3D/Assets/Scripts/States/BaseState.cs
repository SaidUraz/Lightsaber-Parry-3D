using Framework.Enum;

namespace Framework.State
{
    public class BaseState
    {
        #region Variables

        public StateType stateType;

        #endregion Variables

        #region Functions

        public virtual void Initialize() { }
        public virtual void Terminate() { }

        #endregion Functions
    }
}