namespace TurnBasedGameTemplate
{
    /// <summary> Base class for any complex player mechanic. </summary>
    public abstract class BasePlayerMechanics
    {
        protected BasePlayerMechanics(IPlayer player) => Player = player;

        /// <summary> Player reference. </summary>
        protected IPlayer Player { get; }
    }
}