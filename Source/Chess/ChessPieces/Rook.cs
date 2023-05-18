using Chess.Board;
using Microsoft.AspNetCore.Mvc;

namespace Chess.ChessPieces
{
    public class Rook : ChessPiece
    {
        public Rook(int initialX, int initialY, string color, string type) : base(initialX, initialY, color, type)
        {

        }

        public override bool CanMoveTo(int newX, int newY, ChessBoard board)
        {
            return true;
        }

        public override List<Tuple<int, int>> GetPossibleMoves(int x, int y, ChessBoard board)
        {
            return new List<Tuple<int, int>>();
        }
    }
}
