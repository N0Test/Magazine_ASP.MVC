using Magazine_ASP.MVC.DAL;
using Magazine_ASP.MVC.Models;
using Magazine_ASP.MVC.Services.Mapper;
using Magazine_ASP.MVC.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Magazine_ASP.MVC.Services
{
    public class NewsService : INewsService, ITopNewsService, ICategoryNewsService, IMainNewsService, IHomePageNewsService, IShortNewsService
    {
        private readonly ApplicationDBContext _dbContext;

        public IList<NewsModel> News
        {
            get
            {
                return _dbContext.News
                    .Include(x => x.ImageItem)
                    .Select(NewsMapper.Create).ToList();
            }
        }

        public NewsService(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;

        }

        public IList<NewsModel> GetAllNews() => News;
        public NewsModel GetNewsById(int id) => NewsMapper.Create(_dbContext.News.Include(x => x.ImageItem).FirstOrDefault(x => x.Id == id));
        public IList<NewsModel> GetNewsByTag(NewsTag tag) => _dbContext.News.Where(news => news.Tag == tag).Select(NewsMapper.Create).ToList();
        public IList<NewsModel> GetNewsAfterDate(DateTime date) => _dbContext.News.Where(news => news.Date.CompareTo(date) >= 0).Select(NewsMapper.Create).ToList();
        public IList<NewsModel> GetLastestNews(int count)
        {
            var result = News.ToList();
            result.Sort((prev, cur) => cur.Date.CompareTo(prev.Date));
            return result.Take(count).ToList();
        }
        public IList<NewsModel> GetTopNews(int count)
        {
            var result = News.ToList();
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

        public NewsDetailsModel GetDetailsNews(int id)
        {
            var result = new NewsDetailsModel
            {
                News = GetNewsById(id),
                Details = new List<string>
                {
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer molestie, lorem eu eleifend bibendum, augue purus mollis sapien, non rhoncus eros leo in nunc. Donec a nulla vel turpis consectetur tempor ac vel justo. In hac habitasse platea dictumst. Cras nec sollicitudin eros. Nunc eu enim non turpis sagittis rhoncus consectetur id augue. Mauris dignissim neque felis. Phasellus mollis mi a pharetra cursus. Maecenas vulputate augue placerat lacus mattis, nec ornare risus sollicitudin.",
                    "Mauris eu pulvinar tellus, eu luctus nisl. Pellentesque suscipit mi eu varius pulvinar. Aenean vulputate, massa eget elementum finibus, ipsum arcu commodo est, ut mattis eros orci ac risus. Suspendisse ornare, massa in feugiat facilisis, eros nisl auctor lacus, laoreet tempus elit dolor eu lorem. Nunc a arcu suscipit, suscipit quam quis, semper augue.",
                    "Quisque arcu nulla, convallis nec orci vel, suscipit elementum odio. Curabitur volutpat velit non diam tincidunt sodales. Nullam sapien libero, bibendum nec viverra in, iaculis ut eros."
                }
            };
            return result;
        }
        public NewsModel CreateOrUpdate(NewsModel model)
        {
            if (model.Id == default)
            {
                var entity = NewsMapper.Create(model);
                entity.Id = _dbContext.News.Count()+1;
                _dbContext.News.Add(entity);
                return NewsMapper.Create(entity);
            }

            try
            {
                News[model.Id] = model;

            }
            catch (Exception)
            {
                return null;
                //throw new Exception("Not found");
            }
            return model;
        }

    }
}
