namespace WebAPI.Models
{
    public class notes
    {
        public int noteId { get; set; }
        public string noteText { get; set; }
        public string project { get; set; }
        public string creation_timestamp { get; set; }
        public string attribute { get; set; }
    }
}