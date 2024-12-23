namespace Hiring.Models
{
    public class Skill
    {
        public int id { get;set; }
        public int employeeId { get;private set; }
        public Employee employee { get;private set; }
        public string skillName { get; private set; }
        public Skill setEmployeeId(int employeeId)
        {
            this.employeeId = employeeId;
            return this;
        }

        public Skill setEmployee(Employee employee)
        {
            this.employee = employee;
            return this;
        }

        public Skill setSkillName(string skillName)
        {
            this.skillName = skillName;
            return this;
        }

        public Skill build()
        {
            return this;
        }

    }
}
