using Microsoft.AspNetCore.Mvc;

namespace BoardGames.Controllers
{
    public class BoardGamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
