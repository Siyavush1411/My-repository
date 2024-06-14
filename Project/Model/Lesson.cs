using Domain.Enums;

namespace Domain.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string LessonName { get; set; }
        public string Description { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
