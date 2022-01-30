using Magazine_ASP.MVC.DAL.Entities;
using Magazine_ASP.MVC.Models;

namespace Magazine_ASP.MVC.Services.Mapper
{
    public static class NewsMapper
    {
        public static NewsModel Create(NewsEntity entity)
        {
            var imageUrl = entity.ImageItem?.ImageUrl;
            //if (imageUrl.Substring(0, 4) != "http")
            //{
            //    imageUrl = "~/" + imageUrl;
            //}
            return new NewsModel
            {
                Id = entity.Id,
                Image = imageUrl,
                Date = entity.Date,
                Tag = entity.Tag,
                Title = entity.Title,
                ViewsCount = entity.ViewsCount
            };
        }

        public static NewsEntity Create(NewsModel model)
        {
            return new NewsEntity
            {
                //Image = model.ImageItem.ImageUrl,
                Date = model.Date,
                ViewsCount= model.ViewsCount,
                Title = model.Title,
                Tag = model.Tag
            };
        }

        public static NewsEntity Update(NewsEntity entity, NewsModel model)
        {

            //Image = model.ImageItem.ImageUrl,
            entity.Title = model.Title;
            entity.Date = model.Date;
            entity.ViewsCount = model.ViewsCount;
            entity.Tag = model.Tag;

            return entity;
        }
    }
}
