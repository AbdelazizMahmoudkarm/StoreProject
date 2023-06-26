using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class Category
    {
   

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }
        [Display(Name = "اسم الصنف")]
        public String CategoryName { get; set; }
        [ForeignKey("Store")]
        [Display(Name = "المخزن")]
        public int StoreId { get; set; }
        [Display(Name = "المخزن")]
        public Store Store { get; set; }
        public bool IsDelete { set; get; }
        public List<Item> Items { get; set; }
    }
}
