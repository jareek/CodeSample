namespace CodeSample;

internal readonly record struct BattleshipGameSettings(
    int BattleshipCount,
    int DestroyersCount,
    BoardSettings BoardSettings);
