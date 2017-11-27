using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Corporate_System.Models.Database
{
	public class Occupation
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		public string Name { get; set; }
		public decimal Salary { get; set; }
		public bool IsFrontOffice { get; set; }
		public bool IsBackOffice { get; set; }
	}
}