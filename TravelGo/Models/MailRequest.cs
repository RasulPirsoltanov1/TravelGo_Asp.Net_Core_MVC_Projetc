namespace TravelGo.Models
{
    public class MailRequest
    {
        public string Name { get; set; }
        public string MailReceiver{ get; set; }
        public string? Subject{ get; set; }
        public string? Body{ get; set; }
    }
}
