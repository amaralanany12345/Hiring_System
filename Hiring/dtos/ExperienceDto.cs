namespace Hiring.dtos
{
    public class ExperienceDto
    {
        public int id { get; set; }
        public int employeeId { get; set; }
        public string companyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime endDate { get; set; }
        public string description { get; set; }
    }
}
