namespace Hiring.Models
{
    public class Company
    {
        public int id { get; set; }
        public string compnanyName { get; set; }
        public string companyNumber { get; set; }
        public string companyEmail { get; set; }
        public string companyPassword { get; set; }
        public List<Employee> companyEmployees { get; set; } = new List<Employee>();
        public List<Vacancy> companyVacancies { get; set; } = new List<Vacancy>();
    }
}
