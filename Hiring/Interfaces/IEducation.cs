using Hiring.Models;

namespace Hiring.Interfaces
{
    public interface IEducation:IDisposable
    {
        Task<Education> AddEducation(int employeeId, string educationalInstitute, DateTime StartDate, DateTime endDate, string description);
        Task<Education> getEmployeeEducation(int employeeId,int educationId);
        Task<List<Education>> getAllEmployeeEducations(int employeeId);
        Task deleteEmployeeEducation(int employeeId, int educationId);
        Task<Education> updateEmployeeEducation(int employeeId, int educationId, string educationalInstitute, DateTime StartDate, DateTime endDate, string description);
    }
}