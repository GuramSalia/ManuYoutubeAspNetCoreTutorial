using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    public class Menu : Controller
    {
        public IActionResult Index() { return View(); }
    }
}
