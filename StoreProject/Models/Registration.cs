using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class Registration
    {
        [Display(Name ="اسم المستخدم")][MinLength(5,ErrorMessage ="يجب ان يذيد الاسم عن 5 احرف")]
        public string UserName { get; set; }
        
        [Display(Name = "الرقم السري")]
        [MinLength(5, ErrorMessage = "يجب ان يذيد الرقم السري عن 6 احرف")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)][Compare("Password",ErrorMessage ="غير مطابق للرقم السري")]
        [Display(Name = "التاكيد")]
        public string ConfirmPassword { set; get; }
        [NotMapped]
        public string UserRole { set; get; }
    }
}
