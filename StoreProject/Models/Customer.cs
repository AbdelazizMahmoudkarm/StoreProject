using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class Customer
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { set; get; }
        [Display(Name = "الاسم")]
        public String Name { set; get; }
        [Display(Name = "رقم الهاتف")]
        public String  PhoneNumber { get; set; }
        public bool IsBuy { get; set; }
    }
}
