using Hiring.Enums;
using Hiring.Models;

namespace Hiring.Interfaces
{
    public interface IEmployeeVacancy
    {
        Task<List<Employee>> getAllEmployeesAppliedForVacancy(int vacancyId);
        Task<List<Employee>> getAllEmployeesViewedForVacancy(int vacancyId);
        Task<List<Employee>> getAllEmployeesRejectedForVacancy(int vacancyId);
        Task<List<Employee>> getAllEmployeesAcceptedForVacancy(int vacancyId);
        Task<EmployeeVacancies> getAppliedEmployeeState(int vacancyId, int employeeId);
        Task<EmployeeVacancies> updateAppliedEmployeeState(int vacancyId, int employeeId, VacancyState employeeVacancyState);

    }
}
