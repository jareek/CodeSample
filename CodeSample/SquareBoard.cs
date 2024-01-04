namespace CodeSample;

internal readonly ref struct SquareBoard<T> where T : unmanaged
{
    private readonly int _boardHeight;
    private readonly Span<T> _board;

    internal SquareBoard(Span<T> buffer)
    {
        _board = buffer;
        _boardHeight = (int)Math.Ceiling(Math.Sqrt(buffer.Length));
        Guard.IsEqualTo(_boardHeight * _boardHeight, _board.Length);
    }

    public readonly T this[int height, int width]
    {
        get
        {
            Guard.IsTrue(height <= _boardHeight && width <= _boardHeight);
            return _board.Slice(((height - 1) * _boardHeight) + width, 1)[0]; 
        }
        set
        {
            Guard.IsTrue(height <= _boardHeight && width <= _boardHeight);
            _board.Slice(((height - 1) * _boardHeight) + width, 1)[0] = value;
        }
    }
    
    public override string ToString()
    {
        // Get string representation of a board including settings
        throw new NotImplementedException();
    }
}
