using Magazine_ASP.MVC.Models;
using Magazine_ASP.MVC.ViewModel;

namespace Magazine_ASP.MVC.Services
{
    public class NewsService : INewsService, ITopNewsService, ICategoryNewsService, IMainNewsService, IHomePageNewsService, IShortNewsService
    {
        private IList<NewsModel> _news;

        public NewsService()
        {
            _news = new List<NewsModel>();
            
            for (int i = 0; i < 25; i++)
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
        public IList<NewsModel> GetNewsAfterDate(DateTime date) => _news.Where(news => news.Date.CompareTo(date) >= 0).ToList();
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

        public HomePageNewsViewModel GetHomePageNewsViewModel(int topNewsCount, int shortNewsCount, DateTime date)
        {
            var homePageNews = new HomePageNewsViewModel
            {
                TopNews = GetTopNewsViewModel(topNewsCount),
                CategoryNews = GetCategoryNewsViewModel(),
                MainNews = GetMainNewsViewModel(date, shortNewsCount)
            };
            return homePageNews;
        }

        public TopNewsViewModel GetTopNewsViewModel(int newsCount)
        {
            return new TopNewsViewModel
            {
                LastestNews = GetLastestNews(newsCount),
                TopNews = GetTopNews(newsCount)
            };
        }

        public CategoryNewsViewModel GetCategoryNewsViewModel()
        {
            var categoryNews = new CategoryNewsViewModel
            {
                CategoryNews = new Dictionary<NewsTag, IList<NewsModel>>()
            };
            for (int i = 1; i < Enum.GetValues(typeof(NewsTag)).Length; i++)
            {
                categoryNews.CategoryNews.Add((NewsTag)i, GetNewsByTag((NewsTag)i));
            }
            return categoryNews;
        }

        public MainNewsViewModel GetMainNewsViewModel(DateTime date, int count)
        {
            return new MainNewsViewModel
            {
                MainNews = GetNewsAfterDate(date).ToList(),
                ShortMainNews = GetShortNewsModelAfterDate(date, count).ToList()
            };
        }

        public IList<ShortNewsModel> GetShortNewsModelAfterDate(DateTime date, int count)
        {
            return GetNewsAfterDate(date).Take(count).Select(news => new ShortNewsModel { Id = news.Id, Title = news.Title }).ToList();
        }
    }
}
