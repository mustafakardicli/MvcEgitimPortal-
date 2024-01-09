using Microsoft.AspNetCore.Mvc;
using MvcEgitimPortalı.Models;
using MvcEgitimPortalı.ViewModels;

namespace MvcEgitimPortalı.Controllers
{
    public class NoteController : Controller
    {
        private readonly AppDbContext _context;

        public NoteController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NoteListAjax()
        {
            var noteModels = _context.Notes.Select(x => new NoteModel()
            {
                Id = x.Id,
                LessonName = x.LessonName,
                
                Title = x.Title,
                NoteText = x.NoteText,
            }).ToList();

            return Json(noteModels);
        }
        public IActionResult NoteByIdAjax(int id)
        {
            var noteModel = _context.Notes.Where(s => s.Id == id).Select(x => new NoteModel()
            {
                Id = x.Id,
                LessonName = x.LessonName,
                
                Title = x.Title,
                NoteText = x.NoteText,
            }).SingleOrDefault();

            return Json(noteModel);
        }

        [HttpPost]
        public IActionResult NoteAddEditAjax(NoteModel model)
        {
            var sonuc = new SonucModel();
            if (model.Id == 0)
            {

                var note = new Note();
                note.Title = model.Title;
                note.LessonName = model.LessonName;
                
                note.NoteText = model.NoteText;

                _context.Notes.Add(note);
                _context.SaveChanges();
                sonuc.Status = true;
                sonuc.Message = "İşlem Eklendi";
            }
            else
            {
                var user = _context.Notes.FirstOrDefault(x => x.Id == model.Id);
                user.NoteText = model.NoteText;
                user.Title = model.Title;
                user.LessonName = model.LessonName;


                _context.SaveChanges();
                sonuc.Status = true;
                sonuc.Message = "İşlem Güncellendi";
            }

            return Json(sonuc);
        }

        public IActionResult NoteRemoveAjax(int id)
        {
            var note = _context.Notes.FirstOrDefault(x => x.Id == id);
            _context.Notes.Remove(note);
            _context.SaveChanges();

            var sonuc = new SonucModel();
            sonuc.Status = true;
            sonuc.Message = "İşlem Silindi";
            return Json(sonuc);
        }


    }
}

