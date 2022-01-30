using Magazine_ASP.MVC.DAL.Entities;
using Magazine_ASP.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Magazine_ASP.MVC.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<ImageEntity> Images { get; set; }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ImageEntity>().HasData(
                new ImageEntity { Id = 1, ImageUrl = "img/news-350x223-1.jpg" },
                new ImageEntity { Id = 2, ImageUrl = "img/news-350x223-2.jpg" },
                new ImageEntity { Id = 3, ImageUrl = "img/news-350x223-3.jpg" },
                new ImageEntity { Id = 4, ImageUrl = "img/news-350x223-4.jpg" },
                new ImageEntity { Id = 5, ImageUrl = "img/news-350x223-5.jpg" }
                );

            var news = new List<NewsEntity>();

            for (int i = 1; i <= 25; i++)
            {
                var newsEntity = new NewsEntity();
                newsEntity.Id = i;
                newsEntity.Date = DateTime.Now.AddDays(Random.Shared.Next(-5, 0));
                newsEntity.Title = $"#{newsEntity.Id} Title";
                newsEntity.Tag = (NewsTag)Random.Shared.Next(1, 5);
                newsEntity.ViewsCount = Random.Shared.Next(100, 1000);
                newsEntity.ImageId = 1 + (i % 5);
                news.Add(newsEntity);
            }

            modelBuilder.Entity<NewsEntity>().HasData(news);
        }
    }
}
