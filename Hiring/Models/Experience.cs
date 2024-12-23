namespace Hiring.Models
{
    public class Experience
    {
        public int id { get; set; }
        public Employee employee { get; private set; }
        public int employeeId { get; private set; }
        public string companyName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime endDate { get; private set; }
        public string description { get; private set; }

        public Experience SetEmployeeId(int employeeId)
        {
            this.employeeId = employeeId;
            return this;
        }

        public Experience SetEmployee(Employee employee)
        {
            this.employee = employee;
            return this;
        }

        public Experience SetCompanyName(string companyName)
        {
            this.companyName = companyName;
            return this;
        }

        public Experience SetStartDate(DateTime StartDate)
        {
            this.StartDate = StartDate;
            return this;
        }

        public Experience SetEndDate(DateTime endDate)
        {
            this.endDate = endDate;
            return this;
        }

        public Experience SetDescription(string description)
        {
            this.description = description;
            return this;
        }
    }
}
