namespace WebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string NameDepart { get; set; }
        public string Manager { get; set; }
        public virtual List<User>? Users { get; set; }
    }
}
