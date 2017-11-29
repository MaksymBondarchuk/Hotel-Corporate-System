using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Corporate_System.Models.Database
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }


        //public Guid OccupationId { get; set; }
        //public Occupation Occupation { get; set; }

	    public string Password { get; set; }
	    public string Roles { get; set; }
	}
}