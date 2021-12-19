using Magazine_ASP.MVC.ViewModel;

namespace Magazine_ASP.MVC.Services
{
    public interface IShortNewsService
    {
        public IList<ShortNewsModel> GetShortNewsModelAfterDate(DateTime date, int count);
    }
}