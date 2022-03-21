namespace Rating.Models
{
    public class Ratings
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CommunicationPoint { get; set; }
        public int PunctualityPoint { get; set; }
        public int PersonalityPoint { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
