namespace CodeSample;

internal interface IBattleshipBoardProcessor
{
    void SetupBoard(in BattleshipSquareBoard shipsBoard, in BattleshipGameSettings gameSettings);

    (int Height, int Width) GetTargetCoordinates(in BattleshipSquareBoard shotsBoard);

    public void MarkShotWithResult(in (int Height, int Width) targetCoordinates, BoardFieldState result, in BattleshipSquareBoard shotsBoard)
    {
        shotsBoard[targetCoordinates.Height, targetCoordinates.Width] = result;
    }

    public BoardFieldState Verify(in (int Height, int Width) targetCoordinates, in BattleshipSquareBoard shipsBoard)
    {
        // might be a default coomon implementation valid for all board processors
        return BoardFieldState.ShotOnTargetField;
    }

    public bool AllShipsHit(in BattleshipSquareBoard shipsBoard, in BattleshipGameSettings gameSettings)
    {
        // might be a default coomon implementation valid for all board processors
        return false;
    }
}
