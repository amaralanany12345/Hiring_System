namespace Hiring.dtos
{
    public class EducationDto
    {
        public int id { get; set; }
        public int employeeId { get; private set; }
        public string educationalInstitute { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime endDate { get; private set; }
        public string description { get; private set; }
    }
}
