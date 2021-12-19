using Magazine_ASP.MVC.Models;
using Magazine_ASP.MVC.ViewModel;

namespace Magazine_ASP.MVC.Services
{
    public interface IHomePageNewsService
    {
        public HomePageNewsViewModel GetHomePageNewsViewModel(int topNewsCount, int shortNewsCount, DateTime date);
        public NewsDetailsModel GetDetailsNews(int id);
    }
}
