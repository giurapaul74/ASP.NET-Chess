using Chess.Board;

namespace Chess.ChessPieces
{
    public abstract class ChessPiece
    {
        public (int X, int Y) Position { get; set; }
        public bool HasMoved { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public ChessBoard ChessBoard { get; set; }

        public ChessPiece(int initialX, int initialY,string color, string type) 
        {
            Position = (initialX, initialY);
            Color = color;
            Type = type;
            HasMoved = false;
        }

        public void MoveTo(int newX, int newY)
        {
            Position = (newX, newY);
        }

        public abstract List<Tuple<int, int>> GetPossibleMoves(int x, int y, ChessBoard board);
        public abstract bool CanMoveTo(int newX, int newY, ChessBoard chessBoard);
    }
}
