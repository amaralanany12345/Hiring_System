namespace Hiring.Models
{
    public class EasyApply
    {
        public int vacancyId { get; set; }
        public Vacancy vacancy { get; set; }
        public int employeeId { get; set; }
        public Employee employee { get; set; }
        public CV employeeCv { get; set; }
        public int employeeCvId { get; set; }
        public string coverLetter { get; set; }

    }
}
