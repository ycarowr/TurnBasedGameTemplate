namespace TurnBasedGameTemplate.GameData
{
    /// <summary>  All classes dependent of the game data. </summary>
    public interface IGameDataHandler
    {
        IGameData Data { get; }
    }
}