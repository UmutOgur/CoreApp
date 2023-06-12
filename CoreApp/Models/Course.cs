namespace CoreApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        //navigation property
        public virtual Instructor? Instructor { get; set; } = null;
    }
}
