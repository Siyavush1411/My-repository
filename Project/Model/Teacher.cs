namespace Domain.Models
{
    public class Teacher : User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
