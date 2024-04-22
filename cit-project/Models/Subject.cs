namespace cit_project.Models
{
  public class Subject  
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public IEnumerable<Schedule> Schedules { get; set; }
    }
}
