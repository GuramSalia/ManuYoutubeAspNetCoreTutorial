using Microsoft.AspNetCore.Mvc;
using Menu2.Data;
using Menu2.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu2.Controllers
{
    public class Menu2 : Controller
    {

        private readonly Menu2Context _context;

        public Menu2(Menu2Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _context
                .Dishes
                .Include(d=>d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }
    }
}
