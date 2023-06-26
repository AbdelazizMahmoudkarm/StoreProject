using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StoreProject.Models
{
    public class Bill
    {
        [Display(Name ="رقم الفاتوره")][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BillId { set; get; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
       
        [Display(Name ="نوع الفاتوره")]
        public  bool IsBuy { get; set; }
        [Display(Name = "الخصم")]
        public double Discount { get; set; }
        [Required(AllowEmptyStrings =true)]
        [Display(Name = " اسم المستخدم ")]
        public String UserName { get; set; }
        public List<BillItem> BillItems { set; get; }
        public List<Payment> Payments { get; set; }
        [Display(Name ="المدفوع")]
        public double Pay { get; set; }
        [Display(Name ="التاريخ")]
        public DateTime CreationDateTime { set; get; }
        [NotMapped]
        [Display(Name ="ارجاع البيانات للمخزن")]
        public bool ReturnBillItemToStore { get; set; }
        [NotMapped]
        [Display(Name ="مدين")]
        public double Dept { set; get; }


    }
}
