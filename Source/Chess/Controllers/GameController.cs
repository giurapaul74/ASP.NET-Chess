using Chess.Board;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Controllers
{
    public class GameController : Controller
    {
        private ChessBoard _chessBoard;

        public GameController()
        {
            _chessBoard = new ChessBoard();
        }

        public IActionResult Index()
        {
            ChessBoard chessBoard = new ChessBoard();
            chessBoard.InitializeBoard();
            return PartialView("_ChessBoardPartial", chessBoard);
        }

        [HttpPost]
        public IActionResult MakeMove(int startX, int startY, int endX, int endY)
        {
            if (_chessBoard.IsValidMove(startX, startY, endX, endY))
            {
                _chessBoard.MakeMove(startX, startY, endX, endY);
            }

            return View("Index", _chessBoard);
        }
    }
}