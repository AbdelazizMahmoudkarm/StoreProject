using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class Item
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { set; get; }
        [ForeignKey("Measurement")]
        public int MeasureId { get; set; }
        [ForeignKey("Item")]
        public int CategoryId { get; set; }
        public virtual Category Category { set; get; }
        public virtual Measure Measure { get; set; }
        [ForeignKey("Color")]
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public bool IsDelete { set; get; }
        public virtual List<ItemQuantity> ItemQuantities { set; get; }
    }
}
