using Chess.Board;

namespace Chess.ChessPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(string color, string type) : base(color, type)
        {

        }

        public override List<Tuple<int, int>> GetPossibleMoves(int x, int y, ChessBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
