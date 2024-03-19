namespace cit_project.Models
{
  public class Schedule  
  {
      public int Id { get; set; }
      public DateTime StartTime { get; set; }
      public DateTime EndTime { get; set; }
      public int SubjectId { get; set; }
      public int GroupId { get; set; }
      public int TeacherId { get; set; }

      public Subject Subject { get; set; }
      public Group Group { get; set; }
      public Teacher Teacher { get; set; }
  }
}
