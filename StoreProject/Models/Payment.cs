using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentId { set; get; }
        public int BillId { get; set; }
        [Display(Name = "المدفوع")]
        public double Pay { get; set; }
        [Display(Name = "التاريخ")]
        public DateTime Date { set; get; }
    }
}
