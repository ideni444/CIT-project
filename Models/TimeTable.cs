using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Schedule_MVC.Models
{
    //The time table record.
    public class TimeTable
    {
        //Primary key
        public int Id { get; set; }

        //Subject foriegn key
        public int SubjectId { get; set; }

        //Teacher foriegn key
        public int TeacherId { get; set; }


        //Subject link
        public Subject  Subject {get; set;}

        //Teacher link.
        public Teacher Teacher { get; set; }

        //The subject start time
        [DataType(DataType.Time)]
        public DateTime StarTime { get; set; }

        //The subject end time
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        //The day of week.
        public DayOfWeek Day { get; set;  }

    }
}
