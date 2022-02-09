using Magazine_ASP.MVC.DAL;
using Magazine_ASP.MVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Magazine_ASP.MVC.Services
{
    public class ImageDALService : IImageDALService
    {
        private readonly ApplicationDBContext _dbContext;

        public ImageDALService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ImageEntity>> GetList()
        {
            return await _dbContext.Images.ToListAsync();
        }

        public async Task<ImageEntity> Add(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
            {
                throw new System.Exception("Image name can bot be empty");
            }
            var imageEntity = new ImageEntity
            {
                ImageUrl = $"https://itstepspu911vitaly.blob.core.windows.net/images/{imageName}"
            };

            imageEntity = _dbContext.Images.Add(imageEntity).Entity;

            await _dbContext.SaveChangesAsync();
            return imageEntity;
        }

        public async Task<ImageEntity> Get(int id)
        {
            return await _dbContext.Images.FindAsync(id);
        }
    }
}
