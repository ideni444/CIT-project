using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School_Schedule_MVC.Models
{
    //A teacher 
    public class Teacher
    {
        //Primary key
        public int Id { get; set; }

        //Teacher name 
        [Required]
        public string Name { get; set; }

        //Teacher contact number.
        [Required]
        public string ContactNumber { get; set; }

        //Teacher registration id.
        [NotMapped]
        public string TeacherRegistrationName {
            get { return "REG0000" +Id +Name; }
        }
    }
}
