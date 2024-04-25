using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School_Schedule_MVC.Models
{
    //A subject 
    public class Subject
    {
        //Credits 
        public int Credits { get; set; }
        //The subject name
        [Required]
        public string Name { get; set; }
        //Primary key.
        public int Id { get; set; }
        
        //Subject Registraton id 
        [NotMapped]
        public string SubjectRegistrationId {
            get { return "SUB0000"+Name + Id; }
        }

        public IEnumerable<TimeTable> TimeTables { get; set; }
    }
}
