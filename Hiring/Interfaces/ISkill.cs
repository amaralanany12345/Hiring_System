using Hiring.Models;

namespace Hiring.Interfaces
{
    public interface ISkill:IDisposable
    {
        Task<Skill> addSkill(int employeeId,string skillName); 
        Task<Skill> getEmployeeSkill(int employeeId,int skillId); 
        Task<Skill> updateEmployeeSkill(int employeeId,int skillId,string skillName);
        Task<List<Skill>> getAllEmployeeSkills(int employeeId);
        Task deleteEmployeeSkill(int employeeId,int skillId);
    }
}
