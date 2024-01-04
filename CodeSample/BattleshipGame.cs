using System.Runtime.CompilerServices;

namespace CodeSample;

internal class BattleshipGame : IPlayable
{
    private readonly BattleshipGameSettings _settings;
    public BattleshipGame(BattleshipGameSettings settings) 
    {
        _settings = settings;
    }

    public void Play(params IPlayer[] players)
    {
        Guard.IsNotNull(players);
        Guard.IsTrue(players.Length == 2);
        Guard.IsAssignableToType<IBattleshipPlayer>(players[0]);
        Guard.IsAssignableToType<IBattleshipPlayer>(players[1]);

        Play(_settings, (IBattleshipPlayer)players[0], (IBattleshipPlayer)players[1]);
    }

    private static void Play(BattleshipGameSettings settings, IBattleshipPlayer player1, IBattleshipPlayer player2)
    {
        // decided show how it might be implemented using thread stack sacrifying multithreading
        var boardSize = settings.BoardSettings.Height * settings.BoardSettings.Width;
        var gameSide1 = new BattleshipGameSide(1, player1, new (stackalloc BoardFieldState[boardSize]), new(stackalloc BoardFieldState[boardSize]));
        var gameSide2 = new BattleshipGameSide(2, player2, new(stackalloc BoardFieldState[boardSize]), new(stackalloc BoardFieldState[boardSize]));

        SetupSides(in gameSide1, in gameSide2, in settings);

        ref readonly var activeSide = ref SelectStartingSide(in gameSide1, in gameSide2);
        bool activeSideWon = false;
        IPlayer? winner = null;
        while (!activeSideWon)
        {
            var targetCoordinates = activeSide.Player.GetTargetCoordinates(activeSide.ShotsBoard);
            ref readonly var opponent = ref GetActiveSideOpponent(activeSide.Id, in gameSide1, in gameSide2);
            var targetHitResult = opponent.Player.Verify(in targetCoordinates, opponent.ShipsBoard);
            activeSide.Player.MarkShotWithResult(in targetCoordinates, targetHitResult, activeSide.ShotsBoard);
            activeSideWon = activeSide.Player.AllShipsHit(activeSide.ShotsBoard, in settings);
            winner = activeSideWon ? activeSide.Player : null;
            activeSide = ref opponent;
        }   
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void SetupSides(in BattleshipGameSide gameSide1, in BattleshipGameSide gameSide2, in BattleshipGameSettings settings)
    {
        gameSide1.Player.SetupBoard(gameSide1.ShipsBoard, in settings);
        gameSide2.Player.SetupBoard(gameSide2.ShipsBoard, in settings);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ref readonly BattleshipGameSide SelectStartingSide(in BattleshipGameSide gameSide1, in BattleshipGameSide gameSide2)
    {
        // implement random side selection
        return ref gameSide1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ref readonly BattleshipGameSide GetActiveSideOpponent(int activeSideId, in BattleshipGameSide gameSide1, in BattleshipGameSide gameSide2)
    {
        return ref (activeSideId == gameSide1.Id ? ref gameSide2 : ref gameSide1);
    }

    private readonly ref struct BattleshipGameSide
    {
        public BattleshipGameSide(int id, IBattleshipPlayer player, BattleshipSquareBoard shotsBoard, BattleshipSquareBoard shipsBoard)
        {
            Id = id;
            Player = player;
            ShipsBoard = shipsBoard;
            ShotsBoard = shotsBoard;
        }
        public readonly int Id { get; init; }
        public readonly BattleshipSquareBoard ShotsBoard { get; init; }
        public readonly BattleshipSquareBoard ShipsBoard { get; init; }
        public readonly IBattleshipPlayer Player { get; init; }
    }
}
