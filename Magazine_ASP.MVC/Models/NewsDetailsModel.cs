namespace Magazine_ASP.MVC.Models
{
    public class NewsDetailsModel
    {
        public int Id { get; set; }
        public NewsModel News { get; set; }
        public KeyValuePair<string, IList<string>> Details { get; set; }
    }
}
