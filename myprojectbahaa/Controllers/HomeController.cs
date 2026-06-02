using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myprojectbahaa.Data;

namespace myprojectbahaa.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var players = await _context.Players
                .OrderByDescending(p => p.Wins)
                .ThenByDescending(p => p.GoalsScored)
                .ToListAsync();
            return View(players);
        }
    }
}