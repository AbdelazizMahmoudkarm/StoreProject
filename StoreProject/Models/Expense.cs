using System;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Display(Name ="العنصر")][Required]
        public string Element { get; set; }
        [Display(Name = "المبلغ")][Required]
        public double Pay { get; set; }
        [Display(Name = "التاريخ")]
        public DateTime Date { get; set; }
    }
}
