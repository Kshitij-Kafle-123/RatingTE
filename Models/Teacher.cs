namespace Rating.Models
{
    public class Teacher
    {
        public Teacher()
        {
            this.Ratings = new HashSet<Ratings>();
        }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public int? AverageRating { get; set; }
        public ICollection<Ratings> Ratings { get; set; }

       
    }
}
