using TurnBasedGameTemplate;

namespace TurnBasedGameTemplate.Model.Game
{
    /// TODO: Consider to remove this class and solve the IGame ref
    /// TODO: using the Singleton GameData. Or just push the ref to the subclass and remove this base class.
    /// <summary> Small Part of a Turn. </summary>
    public abstract class BaseGameMechanics
    {
        protected BaseGameMechanics(IGame game) => Game = game;

        /// <summary> All game data reference. </summary>
        protected IGame Game { get; }

        protected Observer GameEvents => Game.GameEvents;
    }
}