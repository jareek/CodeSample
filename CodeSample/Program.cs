IPlayer player1 = new BattleshipPlayer("Human Player", new HumanBattleshipBoardProcessor());
IPlayer player2 = new BattleshipPlayer("Computer Player", new ComputerBattleshipBoardProcessor());
BattleshipGameSettings settings = new()
{
    BattleshipCount = 1,
    DestroyersCount = 2,
    BoardSettings = new()
    {
        Height = 10,
        Width = 10,
        UseBoardHeightLetterCoordinates = true,
        UseBoardWidthLetterCoordinates = false
    }
};
IPlayable game = new BattleshipGame(settings);
