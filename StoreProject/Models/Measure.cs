using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class Measure 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MeasureId { get; set; }
        [Display(Name = "اسم وحدة القياس")]
        public String MeasureName { get; set; }
        public bool IsDelete { get; set; }
        
    }
}
