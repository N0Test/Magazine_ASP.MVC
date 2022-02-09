using Magazine_ASP.MVC.DAL.Entities;

namespace Magazine_ASP.MVC.Services
{
    public interface IImageDALService
    {
        Task<ImageEntity> Add(string imageName);
        Task<ImageEntity> Get(int id);
        Task<IList<ImageEntity>> GetList();
    }
}