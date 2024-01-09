namespace MvcEgitimPortalı.Models
{
    public class Subject
    {


        public int SubjectId { get; set; }


        public string SubjectName { get; set; }

        public int LessonId { get; set; }
        

        public Lesson Lesson { get; set; }
    }
}
