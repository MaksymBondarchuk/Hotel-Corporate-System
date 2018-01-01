using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Corporate_System.Models.Database
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public decimal Amount { get; set; }
    }
}