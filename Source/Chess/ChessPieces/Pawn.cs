using Chess.Board;

namespace Chess.ChessPieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(string color, string type) : base(color, type)
        {

        }

        public override List<Tuple<int, int>> GetPossibleMoves(int x, int y, ChessBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
