using System;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Models
{
    public class Masroufat
    {
        public int Id { get; set; }
        [Display(Name ="العنصر")][Required]
        public string Buy { get; set; }
        [Display(Name = "المبلغ")][Required]
        public double pay { get; set; }
        [Display(Name = "التاريخ")]
        public DateTime Date { get; set; }
    }
}
