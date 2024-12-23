namespace Hiring.Models
{
    public class Education
    {
        public int id { get; set; }
        public Employee employee { get; private set; }
        public int employeeId { get; private set; }
        public string educationalInstitute { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime endDate { get;private set; }
        public string description { get; private set; }

        public Education setEmployee(Employee employee) {
            this.employee = employee;
            return this;
        }
        public Education setEmployeeId(int employeeId)
        {
            this.employeeId = employeeId;
            return this;
        }
        public Education setEducationalInstitute(string educationalInstitute) 
        {
            this.educationalInstitute = educationalInstitute;
            return this;
        }

        public Education setStartDate(DateTime startDate)
        {
            this.StartDate = startDate;
            return this;
        }

        public Education setEndDate(DateTime endDate)
        {
            this.endDate= endDate;
            return this;
        }

        public Education setDescription(string description)
        {
            this.description = description;
            return this;
        }
        public Education Build()
        {
            return this;
        }
    }
}
