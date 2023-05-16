using Chess.Board;
using Chess.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;

namespace Chess.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static ChessBoard _chessBoard;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            if (_chessBoard is null)
            {
                _chessBoard = new ChessBoard();
            }
        }

        public IActionResult Index()
        {
            return View(_chessBoard);
        }

        [HttpGet]
        public IActionResult MakeMove(int startX, int startY, int endX, int endY)
        {
            // Try to make the move on the chess board
            bool success = _chessBoard.MovePiece(startX, startY, endX, endY);

            // Return the result
            return Json(new { success = success });
        }

        [HttpGet]
        public IActionResult GetPossibleMoves(int x, int y)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Model invalid.");
            }
            var possibleMoves = _chessBoard.Board[x, y].GetPossibleMoves(x, y, _chessBoard);
            return Json(possibleMoves);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}