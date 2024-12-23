namespace Hiring.Models
{
    public class Employee:User
    {
        public Company? company { get; set; }
        public int? companyId { get; set; }
        public CV? employeeCv { get; set; }
        public int? employeeCvId { get; set; }
        public List<Experience> experiences { get; set; } = new List<Experience>();
        public List<Education> educations { get; set; } = new List<Education>();
        public List<Skill> skills { get; set; } = new List<Skill>();
        public List<Recommendation> recommendationsProvided { get; set; } = new List<Recommendation>();
        public List<Recommendation> recommendationsReceived { get; set; } = new List<Recommendation>();
        public List<EmployeeVacancies> appliedVacancies { get; set; } = new List<EmployeeVacancies>();
    }
}
