using Hiring.Enums;

namespace Hiring.Models
{
    public class EmployeeVacancies
    {
        public int vacancyId { get;set; }
        public Vacancy vacancy { get;set; }
        public int employeeId { get;set; }
        public Employee employee { get;set; }
        public VacancyState vacancyState { get;set; }

    }
}
