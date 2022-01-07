namespace Magazine_ASP.MVC.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get => $"img/news-350x223-{1 + (Id % 5)}.jpg"; }
        public DateTime Date { get; set; }
        public NewsTag Tag { get; set; } = NewsTag.None;
        public int ViewsCount { get; set; } = 0;
    }
}