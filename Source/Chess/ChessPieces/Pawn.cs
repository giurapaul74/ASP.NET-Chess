using Chess.Board;

namespace Chess.ChessPieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(int initialX, int initialY, string color, string type) : base(initialX, initialY, color, type)
        {

        }

        public override bool CanMoveTo(int newX, int newY, ChessBoard chessBoard)
        {
            // Calculate the difference between the current position and the new position
            int deltaX = newX - Position.X;
            int deltaY = newY - Position.Y;

            if (chessBoard is null || chessBoard.Board is null)
            {
                throw new Exception("ChessBoard or ChessBoard.Board is null");
            }

            // If the pawn is moving forward one or two spaces...
            if (Math.Abs(deltaY) == 1 || (Math.Abs(deltaY) == 2 && !HasMoved))
            {
                // ...and it's not moving sideways, and the new position is unoccupied...
                if (deltaX == 0 && chessBoard.Board[newX, newY] == null)
                {
                    // ...the move is legal
                    return true;
                }
            }

            // If none of the above conditions are met, the move is illegal
            return false;
        }

        public override List<Tuple<int, int>> GetPossibleMoves(int x, int y, ChessBoard board)
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();

            // Determine the direction based on the color of the pawn
            int direction = (Color == "white") ? 1 : -1;

            // Check the square directly in front of the pawn
            if (board.IsValidPosition(x, y + direction) && board.IsEmpty(x, y + direction))
            {
                possibleMoves.Add(new Tuple<int, int>(x, y + direction));

                // If the pawn hasn't moved yet, check the square two spaces in front
                if (!HasMoved && board.IsValidPosition(x, y + 2 * direction) && board.IsEmpty(x, y + 2 * direction))
                {
                    possibleMoves.Add(new Tuple<int, int>(x, y + 2 * direction));
                }
            }

            return possibleMoves;
        }
    }
}
