using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myprojectbahaa.Data;
using myprojectbahaa.Models;

namespace myprojectbahaa.Controllers
{
    public class MatchController : Controller
    {
        private readonly AppDbContext _context;

        public MatchController(AppDbContext context)
        {
            _context = context;
        }

        // عرض كل المباريات
        public async Task<IActionResult> Index()
        {
            var matches = await _context.Matches
                .Include(m => m.Player1)
                .Include(m => m.Player2)
                .OrderByDescending(m => m.Date)
                .ToListAsync();
            return View(matches);
        }

        // صفحة إضافة مباراة جديدة
        public IActionResult Create()
        {
            ViewBag.Players = _context.Players.ToList();
            return View();
        }

        // حفظ المباراة الجديدة
        [HttpPost]
        public async Task<IActionResult> Create(Match match)
        {
            match.Date = DateTime.Now;

            // تحديث إحصائيات اللاعبين
            var player1 = await _context.Players.FindAsync(match.Player1Id);
            var player2 = await _context.Players.FindAsync(match.Player2Id);

            if (match.Score1 > match.Score2)
            {
                player1.Wins++; player2.Losses++;
            }
            else if (match.Score1 < match.Score2)
            {
                player2.Wins++; player1.Losses++;
            }
            else
            {
                player1.Draws++; player2.Draws++;
            }

            player1.GoalsScored += match.Score1;
            player1.GoalsConceded += match.Score2;
            player2.GoalsScored += match.Score2;
            player2.GoalsConceded += match.Score1;

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}