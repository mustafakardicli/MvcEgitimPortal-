using MvcEgitimPortalı.Models;

namespace MvcEgitimPortalı.ViewModels
{
    public class NoteModel
    {
        public int Id { get; set; }

        public string LessonName { get; set; }
        public string Title { get; set; }
        public string NoteText { get; set; }
        public Lesson Lesson { get; set; }
    }
}
