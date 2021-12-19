using Magazine_ASP.MVC.Models;

namespace Magazine_ASP.MVC.ViewModel
{
    public class MainNewsViewModel
    {
        public IList<NewsModel> MainNews { get; set; }
        public IList<ShortNewsModel> ShortMainNews { get; set; }
    }
}
