namespace CodeSample;

internal interface IBattleshipPlayer : IPlayer
{
    void SetupBoard(in BattleshipSquareBoard shipsBoard, in BattleshipGameSettings gameSettings);

    (int Height, int Width) GetTargetCoordinates(in BattleshipSquareBoard shotsBoard);

    void MarkShotWithResult(in (int Height, int Width) targetCoordinates, BoardFieldState result, in BattleshipSquareBoard shotsBoard);

    BoardFieldState Verify(in (int Height, int Width) targetCoordinates, in BattleshipSquareBoard shipsBoard);

    bool AllShipsHit(in BattleshipSquareBoard shotsBoard, in BattleshipGameSettings gameSettings);
}
