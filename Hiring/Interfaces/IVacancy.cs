
using Hiring.Models;

namespace Hiring.Interfaces
{
    public interface IVacancy : IDisposable
    {
        Task<Vacancy> addVacancy(int companyId, string Title, string Description, int yearsOfExperience, int Salary, List<string> VacancySkills);
        Task<Vacancy> getVacancy(int vacancyId);
        Task deleteVacancy(int vacancyId);
        Task<List<Vacancy>> getAllCompanyVacancies(int companyId);
        Task<List<Vacancy>> getAllVacancies();
        Task<EasyApply> applyForVacancy(int vacancyId, int employeeId ,string coverLetter);
    }
}