namespace gesteventos.Models
{
    public class Events
    {
        public Events()
        {

        }
        public int EventId { get; set; }
        public string Place { get; set; }
        public string Subject { get; set; }
        public string EventDate { get; set; }
        public int PeopleQty { get; set; }
        public string Loth { get; set; }
        public string ImgUrl { get; set; }
    }
}