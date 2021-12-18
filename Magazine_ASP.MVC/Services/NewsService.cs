using Magazine_ASP.MVC.Models;

namespace Magazine_ASP.MVC.Services
{
    public class NewsService : INewsService
    {
        private IList<NewsModel> _news;

        public NewsService()
        {
            _news = new List<NewsModel>();
            
            for (int i = 0; i < 10; i++)
            {
                var newsModel = new NewsModel();
                newsModel.Id = i;
                newsModel.Date = DateTime.Now.AddDays(Random.Shared.Next(-5, 0));
                newsModel.Title = $"#{newsModel.Id} Title";
                newsModel.Image = $"img/news-350x223-{1 + (newsModel.Id % 5)}.jpg";
                newsModel.Tag = (NewsTag)Random.Shared.Next(1, 5);
                newsModel.ViewsCount = Random.Shared.Next(100, 1000);
                _news.Add(newsModel);
            }

        }

        public IList<NewsModel> GetAllNews() => _news;
        public NewsModel GetNewsById(int id) => _news.FirstOrDefault(news => news.Id == id);
        public IList<NewsModel> GetNewsByTag(NewsTag tag) => _news.Where(news => news.Tag == tag).ToList();
        public IList<NewsModel> GetNewsByDate(DateTime date) => _news.Where(news => news.Date.CompareTo(date) == 0).ToList();
        public IList<NewsModel> GetLastestNews(int count)
        {
            var result = _news.ToList();
            result.Sort((prev, cur) => cur.Date.CompareTo(prev.Date));
            return result.Take(count).ToList();
        }
        public IList<NewsModel> GetTopNews(int count)
        {
            var result = _news.ToList();
            result.Sort((prev, cur) => cur.ViewsCount.CompareTo(prev.ViewsCount));
            return result.Take(count).ToList();
        }
    }
}
