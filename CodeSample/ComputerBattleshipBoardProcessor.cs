namespace CodeSample;

internal class ComputerBattleshipBoardProcessor : IBattleshipBoardProcessor
{
    public void SetupBoard(in BattleshipSquareBoard board, in BattleshipGameSettings gameSettings)
    {
        // prepare the computer board for the game
    }

    public (int Height, int Width) GetTargetCoordinates(in BattleshipSquareBoard shotsBoard)
    {
        // analyze the shots results and select the most possible next successful hit coordinates
        return (1, 1);
    }
}
