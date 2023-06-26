using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class Store 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StoreId { set; get; }
        [Display(Name = "اسم المخزن")]
        public  String StoreName { set; get; }
        public bool IsDelete { get; set; }
    }
}
