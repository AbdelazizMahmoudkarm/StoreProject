using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class BrandImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public string ImageName { get; set; }
        public string StringImage { get; set; }
        //[NotMapped]
        //public byte[] Image { set; get; }
    }
}
