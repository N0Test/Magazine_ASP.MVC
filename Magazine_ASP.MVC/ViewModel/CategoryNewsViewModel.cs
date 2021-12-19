using Magazine_ASP.MVC.Models;

namespace Magazine_ASP.MVC.ViewModel
{
    public class CategoryNewsViewModel
    {
        public IDictionary<NewsTag, IList<NewsModel>> CategoryNews { get; set; }
    }
}
