using Magazine_ASP.MVC.Models;

namespace Magazine_ASP.MVC.ViewModel
{
    public class TopNewsViewModel
    {
        public IList<NewsModel> LastestNews { get; set; }
        public IList<NewsModel> TopNews { get; set; }
    }
}
