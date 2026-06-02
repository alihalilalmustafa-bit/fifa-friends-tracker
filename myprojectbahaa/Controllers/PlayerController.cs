using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myprojectbahaa.Data;
using myprojectbahaa.Models;

namespace myprojectbahaa.Controllers
{
    public class PlayerController : Controller
    {
        private readonly AppDbContext _context;

        public PlayerController(AppDbContext context)
        {
            _context = context;
        }

        // عرض كل اللاعبين
        public async Task<IActionResult> Index()
        {
            var players = await _context.Players.ToListAsync();
            return View(players);
        }

        // صفحة إضافة لاعب جديد
        public IActionResult Create()
        {
            return View();
        }

        // حفظ اللاعب الجديد
        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Players.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // حذف لاعب
        public async Task<IActionResult> Delete(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}