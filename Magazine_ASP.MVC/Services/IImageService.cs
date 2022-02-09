using Magazine_ASP.MVC.Models;

namespace Magazine_ASP.MVC.Services
{
    public interface IImageService
    {
        Task<ImageViewModel> GetFile(string fileName);
        Task<IList<string>> GetImages();
        Task<string> Upload(string fileName, Stream file);
    }
}