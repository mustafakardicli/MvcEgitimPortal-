using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcEgitimPortalı.Models;
using MvcEgitimPortalı.ViewModels;

namespace MvcEgitimPortalı.Controllers
{
    public class LessonController : Controller
    {
        private readonly AppDbContext _context;

        public LessonController(AppDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Matematik()
        {
            return View();
        }

        public IActionResult Türkçe()
        {
            return View();
        }

        public IActionResult İngilizce()
        {
            return View();
        }

        
    }
}
