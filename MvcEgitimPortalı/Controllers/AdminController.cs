using AspNetCoreHero.ToastNotification.Abstractions;
using MvcEgitimPortalı.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NuGet.Protocol;
using MvcEgitimPortalı.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EğitimPortalı.Controllers
{

    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IConfiguration _config;
        private readonly IFileProvider _fileProvider;

        public AdminController(AppDbContext appDbContext, IConfiguration config, IFileProvider fileProvider, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {

            _context = appDbContext;
            _config = config;
            _fileProvider = fileProvider;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AdminUser()
        {
            
            return View();
            
        }

        public async Task< IActionResult> GetRoleList()
        {
            
            return View();
        }

        public IActionResult RoleAdd()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RoleAdd(AppRole model)
        {
            var role = await _roleManager.FindByNameAsync(model.Name);
            if (role == null)
            {

                var newrole = new AppRole();
                newrole.Name = model.Name; ;
                await _roleManager.CreateAsync(newrole);
            }
            return RedirectToAction("GetRoleList");
        }


        public IActionResult Instructor()
        {
            return View();
        }



        [HttpGet]
        public IActionResult InstructorListAjax()
        {
            var instructors = _context.Instructors.ToList();
            return Json(instructors);
        }

        [HttpGet]
        public IActionResult InstructorByIdAjax(int id)
        {
            var instructor = _context.Instructors.FirstOrDefault(i => i.Id == id);
            return Json(instructor);
        }

        [HttpPost]
        public IActionResult InstructorAddEditAjax(int id, string fullName, int lessonId, string email)
        {
            try
            {
                var existingInstructor = _context.Instructors.FirstOrDefault(i => i.Id == id);

                if (existingInstructor != null)
                {
                    // Eğitmen zaten varsa güncelle
                    existingInstructor.FullName = fullName;
                    existingInstructor.LessonId = lessonId;
                    existingInstructor.Email = email;
                }
                else
                {
                    // Yeni eğitmen ekleyin
                    var newInstructor = new Instructor
                    {
                        Id = id, // Eğer ID değeri otomatik artış ile atanıyorsa bu satırı kaldırabilirsiniz
                        FullName = fullName,
                        LessonId = lessonId,
                        Email = email
                    };

                    _context.Instructors.Add(newInstructor);
                }

                _context.SaveChanges();

                return Json(new { status = true, message = "Başarıyla kaydedildi veya güncellendi." });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Kaydedilirken bir hata oluştu." });
            }
        }

        [HttpGet]
        public IActionResult InstructorRemoveAjax(int id)
        {
            try
            {
                var instructorToRemove = _context.Instructors.FirstOrDefault(i => i.Id == id);

                if (instructorToRemove != null)
                {
                    // Eğitmeni veritabanından kaldırın
                    _context.Instructors.Remove(instructorToRemove);
                    _context.SaveChanges();
                }

                return Json(new { status = true, message = "Başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Silinirken bir hata oluştu." });
            }
        }
    



    public IActionResult Exam()
        {
            return View();
        }

        



        public IActionResult AddSubject() 
        { 
            return View();
        }

        public IActionResult Lesson()
        {
            return View();
        }

        public IActionResult LessonListAjax()
        {

            var lessonModels = _context.Lessons.Select(x => new LessonModel()
            {
                LessonId = x.LessonId,
                LessonName = x.LessonName,
            }).ToList();
            return Json(lessonModels);
        }

        public IActionResult LessonByIdAjax(int lessonId)
        {
            var lessonModels = _context.Lessons
                .Where(s => s.LessonId == lessonId)
                .Select(x => new LessonModel()
                {
                    LessonId = x.LessonId,
                    LessonName = x.LessonName,
                })
                .SingleOrDefault();

            return Json(lessonModels);
        }

        [HttpPost]
        public IActionResult LessonAddEditAjax(LessonModel model)
        {
            var result = new SonucModel();
            if (model.LessonId == 0)
            {
                if (_context.Lessons.Any(c => c.LessonName == model.LessonName))
                {
                    result.Status = false;
                    result.Message = "Girilen Ders Kayıtlıdır!";
                    return Json(result);
                }

                var lesson = new Lesson();
                lesson.LessonName = model.LessonName;
                _context.Lessons.Add(lesson);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Ders Eklendi";
            }
            else
            {
                var category = _context.Lessons.FirstOrDefault(x => x.LessonId == model.LessonId);
                category.LessonName = model.LessonName;
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Ders Güncellendi";
            }
            return Json(result);
        }

        public IActionResult LessonRemoveAjax(int lessonId)
        {
            var category = _context.Lessons.FirstOrDefault(x => x.LessonId == lessonId);
            _context.Lessons.Remove(category);
            _context.SaveChanges();

            var result = new SonucModel();
            result.Status = true;
            result.Message = "Ders Silindi";
            return Json(result);
        }


        public IActionResult Subject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubjectAddEditAjax(int subjectId, string subjectName, int lessonId)
        {
            try
            {
                if (subjectId == 0)
                {
                    // Yeni konu ekleme işlemi
                    var newSubject = new Subject
                    {
                        SubjectName = subjectName,
                        LessonId = lessonId
                    };

                    _context.Subjects.Add(newSubject);
                }
                else
                {
                    // Konu düzenleme işlemi
                    var existingSubject = _context.Subjects.Find(subjectId);

                    if (existingSubject != null)
                    {
                        existingSubject.SubjectName = subjectName;
                        existingSubject.LessonId = lessonId;
                    }
                    else
                    {
                        return Json(new { status = false, message = "Konu bulunamadı." });
                    }
                }

                _context.SaveChanges();

                return Json(new { status = true, message = "İşlem başarıyla tamamlandı." });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult SubjectByIdAjax(int subjectId)
        {
            var subject = _context.Subjects.Find(subjectId);

            if (subject != null)
            {
                return Json(new { subjectId = subject.SubjectId, subjectName = subject.SubjectName, lessonId = subject.LessonId });
            }
            else
            {
                return Json(new { status = false, message = "Konu bulunamadı." });
            }
        }

        [HttpGet]
        public IActionResult SubjectRemoveAjax(int subjectId)
        {
            var subject = _context.Subjects.Find(subjectId);

            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();

                return Json(new { status = true, message = "Konu başarıyla silindi." });
            }
            else
            {
                return Json(new { status = false, message = "Konu bulunamadı." });
            }
        }

        [HttpGet]
        public IActionResult SubjectListAjax()
        {
            var subjects = _context.Subjects.ToList();

            return Json(subjects);
        }












    }
}
