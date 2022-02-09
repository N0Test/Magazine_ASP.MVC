using Magazine_ASP.MVC.DAL.Entities;
using Magazine_ASP.MVC.Models;

namespace Magazine_ASP.MVC.Services.Mapper
{
    public static class ImagesMapper
    {
        public static ImageModel Create(ImageEntity entity)
        {
            var url = new Uri(entity.ImageUrl);
            string name = Path.GetFileName(url.AbsolutePath);

            return new ImageModel
            {
                Id = entity.Id,
                Url = entity.ImageUrl,
                Name = name,
            };
        }
    }
}
