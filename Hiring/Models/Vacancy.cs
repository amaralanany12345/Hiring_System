namespace Hiring.Models
{
    public class Vacancy
    {
        public int id { get;set; }
        public Company company { get; set; }
        public int companyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int yearsOfExperience { get; set; }
        public int  Salary { get; set; }
        public List<string> VacancySkills { get; set; } = new List<string>(); 
        //public Dictionary<string, string> VacancySkills { get; set; }

        public List<EmployeeVacancies> appliedEmployees { get; set; } = new List<EmployeeVacancies>();
        public Vacancy setCompany(Company company)
        {
            this.company = company;

            return this;
        }
        public Vacancy setCompanyId(int companyId)
        {
            this.companyId= companyId;
            return this;
        }
        public Vacancy setTitle(string title)
        {
            this.Title= title;
            return this;
        }
        public Vacancy setDescription(string description)
        {
            this.Description = description;
            return this;
        }
        public Vacancy setSalary(int salary)
        {
            this.Salary= salary;
            return this;
        }
        public Vacancy setYearsOfExperience(int yearsOfExperiences)
        {
            this.yearsOfExperience = yearsOfExperiences;
            return this;
        }
        public Vacancy setSkills(List<string> vacancySkills)
        {
            this.VacancySkills = vacancySkills;
            return this;
        }
    }
}
