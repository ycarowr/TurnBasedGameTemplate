using TurnBasedGameTemplate.GameData;
using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Tools.Patterns.Observer;
using TurnBasedGameTemplate.Tools.Patterns.StateMachine;

namespace TurnBasedGameTemplate.Model.TurnBasedFSM
{
    /// <summary> 
    ///     The base of all the battle states. States work as controllers to provide access to a funcionality in the
    ///     model.
    /// </summary>
    public abstract class BaseBattleState : IState, IListener, IRestartGame
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        protected BaseBattleState(TurnBasedFsm fsm, IGameData gameData, Configurations.Configurations configurations)
        {
            Fsm = fsm;
            GameData = gameData;
            Configurations = configurations;

            //Subscribe game events 
            Tools.Patterns.GameEvents.GameEvents.Instance.AddListener(this);
            IsInitialized = true;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        protected Configurations.Configurations Configurations { get; }
        protected IGameData GameData { get; }
        public TurnBasedFsm Fsm { get; set; }
        public bool IsInitialized { get; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        public virtual void OnClear()
        {
            //Unsubscribe game events
            if (Tools.Patterns.GameEvents.GameEvents.Instance)
                Tools.Patterns.GameEvents.GameEvents.Instance.RemoveListener(this);
        }

        public virtual void OnInitialize()
        {
        }

        public virtual void OnEnterState()
        {
        }

        public virtual void OnExitState()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnNextState(IState next)
        {
        }

        protected virtual void OnNextState(BaseBattleState nextState)
        {
            Fsm.PopState();
            Fsm.PushState(nextState);
        }

        void IRestartGame.OnRestart()
        {
            OnClear();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}