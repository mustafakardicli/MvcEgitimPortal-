namespace MvcEgitimPortalı.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
