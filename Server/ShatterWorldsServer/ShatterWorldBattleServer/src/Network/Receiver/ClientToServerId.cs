namespace ShatterWorldBattleServer.Handlers
{
    public enum ClientToServerId : ushort
    {
        loginInfo = 1,
        chosenCharacters = 2,
        firstTurn = 3,
        endTurn = 4,
        move = 5,
        attack = 6,
        spell = 7
    }
    
}