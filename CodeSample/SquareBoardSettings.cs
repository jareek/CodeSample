namespace CodeSample;

internal readonly record struct BoardSettings(
    int Height,
    int Width,
    bool UseBoardHeightLetterCoordinates,
    bool UseBoardWidthLetterCoordinates);
