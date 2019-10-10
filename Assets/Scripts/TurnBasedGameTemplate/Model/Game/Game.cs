using System.Collections.Generic;
using TurnBasedGameTemplate.Configurations;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Model.TurnLogic;
using TurnBasedGameTemplate.Tools.Patterns.Observer;

namespace TurnBasedGameTemplate.Model.Game
{
    /// <summary>  Simple concrete Game Implementation.TODO: Consider to break this class down into small partial classes. </summary>
    public class Game : IGame
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public Game(List<IPlayer> players, GameParameters gameParameters, Observer gameEvents)
        {
            GameParameters = gameParameters;
            GameEvents = gameEvents;

            TurnLogic = new TurnLogic.TurnLogic(players);
            ProcessPreStartGame = new PreStartGameMechanics(this);
            ProcessStartGame = new StartGameMechanics(this);
            ProcessStartPlayerTurn = new StartPlayerTurnMechanics(this);
            ProcessFinishPlayerTurn = new FinishPlayerTurnMechanics(this);
            ProcessFinishGame = new FinishGameMechanics(this);

            AddMechanic(ProcessPreStartGame);
            AddMechanic(ProcessStartGame);
            AddMechanic(ProcessStartPlayerTurn);
            AddMechanic(ProcessFinishPlayerTurn);
            AddMechanic(ProcessFinishGame);
        }

        #endregion


        void AddMechanic(BaseGameMechanics mechanic) => Mechanics.Add(mechanic);

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        public List<IPlayer> Players => TurnLogic.Players;
        public bool IsGameStarted { get; set; }
        public bool IsGameFinished { get; set; }
        public bool IsTurnInProgress { get; set; }
        public GameParameters GameParameters { get; }
        public Observer GameEvents { get; }

        #region Processes

        public List<BaseGameMechanics> Mechanics { get; set; } = new List<BaseGameMechanics>();
        public ITurnLogic TurnLogic { get; set; }
        PreStartGameMechanics ProcessPreStartGame { get; }
        StartGameMechanics ProcessStartGame { get; }
        StartPlayerTurnMechanics ProcessStartPlayerTurn { get; }
        FinishPlayerTurnMechanics ProcessFinishPlayerTurn { get; }
        FinishGameMechanics ProcessFinishGame { get; }

        #endregion

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Execution

        public void PreStartGame() => ProcessPreStartGame.Execute();

        public void StartGame() => ProcessStartGame.Execute();

        public void StartCurrentPlayerTurn() => ProcessStartPlayerTurn.Execute();

        public void FinishCurrentPlayerTurn() => ProcessFinishPlayerTurn.Execute();

        public void ExecuteAiTurn(PlayerSeat seat)
        {
        }

        public void ForceWin(PlayerSeat seat)
        {
            var player = TurnLogic.GetPlayer(seat);
            ProcessFinishGame.Execute(player);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}