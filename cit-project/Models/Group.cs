namespace cit_project.Models
{
  public class Group  
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Student> Students { get; set; }
  }
}