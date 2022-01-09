using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Magazine_ASP.MVC.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "максимум 20 символів")]
        [RegularExpression(@"[A-Za-z0-9 ]+", ErrorMessage = "Тільки латинські букви")]
        public string Title { get; set; }
        public string Image { get => $"img/news-350x223-{1 + (Id % 5)}.jpg"; }
        [DisplayName("Publish date")]
        public DateTime Date { get; set; }
        [DisplayName("News Tag")]
        public NewsTag Tag { get; set; } = NewsTag.None;
        [DisplayName("View Count")]
        [Range(0, 1000000, ErrorMessage = "значення повинно лежати в межах від 0 до 1000000")]
        public int ViewsCount { get; set; } = 0;
    }
}