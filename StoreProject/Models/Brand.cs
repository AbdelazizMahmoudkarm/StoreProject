using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class Brand
    {
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BrandId { get; set; }
        public String BrandName { get; set; }
        public string Title { set; get; }
        public string Owner { get; set; }
        public string Place { set; get; }
        public string  First_PhoneNumer { get; set; }
        public string Second_PhoneNumber { get; set; }
        public string Company { get; set; }
        public List<BrandImage> BrandImages { get; set; }

    }
}
