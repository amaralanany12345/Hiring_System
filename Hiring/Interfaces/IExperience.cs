using Hiring.Models;

namespace Hiring.Interfaces
{
    public interface IExperience:IDisposable
    {
        Task<Experience> addExperience(int employeeId,string companyName,DateTime startDate, DateTime endDate,string description);
        Task<Experience> getEmployeeExperience(int employeeId,int experienceId);
        Task<Experience> updateEmployeeExperience(int employeeId,int experienceId,string companyName, DateTime startDate, DateTime endDate, string description);
        Task<List<Experience>> getAllEmployeeExperiences(int employeeId);
        Task deleteExperience(int employeeId, int experienceId);
    }
}
