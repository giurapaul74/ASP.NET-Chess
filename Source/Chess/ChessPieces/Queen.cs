using Chess.Board;

namespace Chess.ChessPieces
{
    public class Queen : ChessPiece
    {
        public Queen(string color, string type) : base(color, type)
        {

        }

        public override List<Tuple<int, int>> GetPossibleMoves(int x, int y, ChessBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
