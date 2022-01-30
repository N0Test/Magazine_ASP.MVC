using System.ComponentModel.DataAnnotations;

namespace Magazine_ASP.MVC.DAL.Entities
{
    public class ImageEntity
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}