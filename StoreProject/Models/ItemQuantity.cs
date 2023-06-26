using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class ItemQuantity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemQuantityId { get; set; }
        public int ItemId { get; set; }
        public Item Item { set; get; }
        [Display(Name = "الكميه")]
        public double Quantity { get; set; }
        [Display(Name = "سعر البيع")]
        public double SalePrice { get; set; }
        [Display(Name = "سعر الشراء")]
        public double BuyPrice { get; set; }
        [Display(Name = "العدد في الكرتونه")]
        public double Cartona { set; get; }
        public bool IsDelete { get; set; }
    }
}
