using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StoreProject.Models
{
    public class BillItem 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BillItemId { get; set; }
        [ForeignKey("Bill")]
        [Display(Name = "رقم الفاتوره")]
        public int BillId { get; set; }
        [Display(Name = "اسم الصنف")]
        public String ItemName { get; set; }
        [Display(Name = "الكميه")]
        public double Quantity { get; set; }
        [ForeignKey("ItemQantity")]
        public int ItemQuantityId { get; set; }
        [NotMapped]
        public int MeasureId { get; set; }
        [NotMapped]
        public int ColorId { get; set; }
        public ItemQuantity ItemQantity { get; set; }
        [Display(Name =  " الكميه المرتجعه")]
        public double DiscardQuantity { set; get; }
        [Display(Name ="السعر")]
        public double BuyPrice { get; set; }
        [Display(Name = "سعر البيع ")]
        public double SalePrice { get; set; }
        [NotMapped]
        public int StoreId { get; set; }

    }
}
