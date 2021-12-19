using Magazine_ASP.MVC.Models;

namespace Magazine_ASP.MVC.Services
{
    public interface INewsService
    {
        public IList<NewsModel> GetAllNews();
        public NewsModel GetNewsById(int id);
        public IList<NewsModel> GetNewsByTag(NewsTag tag);
        public IList<NewsModel> GetNewsAfterDate(DateTime date);
        public IList<NewsModel> GetLastestNews(int count);
        public IList<NewsModel> GetTopNews(int count);
    }
}
