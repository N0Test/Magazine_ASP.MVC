using Magazine_ASP.MVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magazine_ASP.MVC.DAL.Entities
{
    public class NewsEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public NewsTag Tag { get; set; } = NewsTag.None;
        public int ViewsCount { get; set; } = 0;
        public int? ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual ImageEntity ImageItem { get; set; }
    }
}
