using Magazine_ASP.MVC.ViewModel;

namespace Magazine_ASP.MVC.Services
{
    public interface IMainNewsService
    {
        public MainNewsViewModel GetMainNewsViewModel(DateTime date, int count);
    }
}