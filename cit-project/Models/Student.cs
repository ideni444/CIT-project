namespace cit_project.Models
{
  public class Student  
  {
      public int Id { get; set; }
      public int GroupId { get; set; }
      public string Name { get; set; }
      public string Surname { get; set; }

      public Group Group { get; set; }
  }
}
