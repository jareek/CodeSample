namespace CodeSample;

internal class HumanBattleshipBoardProcessor : IBattleshipBoardProcessor
{
    public void SetupBoard(in BattleshipSquareBoard board, in BattleshipGameSettings gameSettings)
    {
        // ask human for a ships coordinates depanding on game settings
        
    }

    public (int Height, int Width) GetTargetCoordinates(in BattleshipSquareBoard shotsBoard)
    {
        // analyze the shots, select and next
        return (2, 2);
    }
}
