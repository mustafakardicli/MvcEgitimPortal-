using MvcEgitimPortalı.Models;

namespace MvcEgitimPortalı.ViewModels
{
    public class InstructorModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
