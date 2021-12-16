namespace Magazine_ASP.MVC.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public NewsTag Tag { get; set; } = NewsTag.None;
        public int ViewsCount { get; set; } = 0;
    }

    public enum NewsTag
    {
        None,
        Sports,
        Businessm,
        Technology,
        Entertainment,
    }
}