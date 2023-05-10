using Chess.ChessPieces;

namespace Chess.Board
{
    public class ChessBoard
    {
        public ChessPiece[,] Board { get; private set; }

        public ChessBoard()
        {
            InitializeBoard();
        }
        
        public void InitializeBoard()
        {
            Board = new ChessPiece[8,8];

            for (int i = 0; i < 8; i++)
            {
                Board[i, 1] = new Pawn("black", "pawn");
                Board[i, 6] = new Pawn("white", "pawn");
            }

            Board[0, 0] = new Rook("black", "rook");
            Board[7, 0] = new Rook("black", "rook");
            Board[0, 7] = new Rook("white", "rook");
            Board[7, 7] = new Rook("white", "rook");

            Board[1, 0] = new Knight("black", "knight");
            Board[6, 0] = new Knight("black", "knight");
            Board[1, 7] = new Knight("white", "knight");
            Board[6, 7] = new Knight("white", "knight");

            Board[2, 0] = new Bishop("black", "bishop");
            Board[5, 0] = new Bishop("black", "bishop");
            Board[2, 7] = new Bishop("white", "bishop");
            Board[5, 7] = new Bishop("white", "bishop");

            Board[3, 0] = new Queen("black", "queen");
            Board[3, 7] = new Queen("white", "queen");

            Board[4, 0] = new King("black", "king");
            Board[4, 7] = new King("white", "king");
        }

        public bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            ChessPiece startPiece = Board[startX, startY];

            if (startPiece == null)
            {
                return false;
            }

            List<Tuple<int, int>> possibleMoves = startPiece.GetPossibleMoves(startX, startY, this);

            return possibleMoves.Any(move => move.Item1 == endX && move.Item2 == endY);
        }

        public void MakeMove(int startX, int startY, int endX, int endY)
        {
            ChessPiece startPiece = Board[startX, startY];
            Board[endX, endY] = startPiece;
            Board[startX, startY] = null;
        }

        public bool IsInCheck(string color)
        {
            int kingX = -1;
            int kingY = -1;

            // Find the position of the king
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    ChessPiece piece = Board[x, y];
                    if (piece != null && piece.Type == "king" && piece.Color == color)
                    {
                        kingX = x;
                        kingY = y;
                        break;
                    }
                }

                if (kingX != -1 && kingY != -1)
                {
                    break;
                }
            }

            // Check if any opponent pieces can capture the king
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    ChessPiece piece = Board[x, y];
                    if (piece != null && piece.Color != color)
                    {
                        List<Tuple<int, int>> possibleMoves = piece.GetPossibleMoves(x, y, this);
                        if (possibleMoves.Any(move => move.Item1 == kingX && move.Item2 == kingY))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IsCheckmate(string color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            for (int startX = 0; startX < 8; startX++)
            {
                for (int startY = 0; startY < 8; startY++)
                {
                    ChessPiece piece = Board[startX, startY];
                    if (piece != null && piece.Color != color)
                    {
                        List<Tuple<int, int>> possibleMoves = piece.GetPossibleMoves(startX, startY, this);

                        foreach (var move in possibleMoves)
                        {
                            int endX = move.Item1;
                            int endY = move.Item2;

                            ChessPiece capturedPiece = Board[endX, endY];
                            Board[endX, endY] = piece;
                            Board[startX, startY] = null;

                            bool isStillInCheck = IsInCheck(color);

                            Board[startX, startY] = piece;
                            Board[endX, endY] = capturedPiece;

                            if (!isStillInCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
