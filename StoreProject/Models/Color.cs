using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class Color 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ColorId { get; set; }
        [Display(Name = "اللون")]
        public string ColorName { get; set; }
        public bool IsDelete { get; set; }
    }
}
