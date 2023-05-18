using Chess.Board;

namespace Chess.ChessPieces
{
    public class King : ChessPiece
    {
        public King(int initialX, int initialY, string color, string type) : base(initialX, initialY, color, type)
        {

        }

        public override bool CanMoveTo(int newX, int newY, ChessBoard chessBoard)
        {
            return true;
        }

        public override List<Tuple<int, int>> GetPossibleMoves(int x, int y, ChessBoard board)
        {
            return new List<Tuple<int, int>>();
        }
    }
}
