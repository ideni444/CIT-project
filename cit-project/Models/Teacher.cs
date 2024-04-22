namespace cit_project.Models
{
  public class Teacher  
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public IEnumerable<Schedule> Schedules { get; set; }
    }
}
