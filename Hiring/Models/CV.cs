namespace Hiring.Models
{
    public class CV
    {
        public int id { get; set; }
        public int employeeId { get; set; }
        public Employee employee { get; set; }
        public string fileName { get; set; }
        public string filePath { get; set; }
    }
}
