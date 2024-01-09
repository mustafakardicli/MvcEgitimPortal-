using MvcEgitimPortalı.Models;

namespace MvcEgitimPortalı.ViewModels
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public string LessonName { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        

        
    }
}
