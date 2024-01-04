namespace CodeSample;

internal sealed class BattleshipPlayer : IBattleshipPlayer
{
    public string Name { get; init; }
    private readonly IBattleshipBoardProcessor _boardProcessor;

    internal BattleshipPlayer(string name, IBattleshipBoardProcessor boardProcessor) 
    {
        Name = name;
        _boardProcessor = boardProcessor;
    }


    public void SetupBoard(in BattleshipSquareBoard shipsBoard, in BattleshipGameSettings gameSettings) => _boardProcessor.SetupBoard(in shipsBoard, in gameSettings);

    public (int Height, int Width) GetTargetCoordinates(in BattleshipSquareBoard shotsBoard) => _boardProcessor.GetTargetCoordinates(in shotsBoard);

    public void MarkShotWithResult(in (int Height, int Width) targetCoordinates, BoardFieldState result, in BattleshipSquareBoard shotsBoard) => _boardProcessor.MarkShotWithResult(in targetCoordinates, result, in shotsBoard);    

    public BoardFieldState Verify(in (int Height, int Width) targetCoordinates, in BattleshipSquareBoard shipsBoard) => _boardProcessor.Verify(targetCoordinates, in shipsBoard);

    public bool AllShipsHit(in BattleshipSquareBoard shotsBoard, in BattleshipGameSettings gameSettings) => _boardProcessor!.AllShipsHit(in shotsBoard, in gameSettings);
}
