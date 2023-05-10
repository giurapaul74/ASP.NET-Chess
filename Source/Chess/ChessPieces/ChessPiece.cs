using Chess.Board;

namespace Chess.ChessPieces
{
    public abstract class ChessPiece
    {
        public string Color { get; set; }
        public string Type { get; set; }

        public ChessPiece(string color, string type) 
        {
            Color = color;
            Type = type;
        }

        public abstract List<Tuple<int, int>> GetPossibleMoves(int x, int y, ChessBoard board);
    }
}
