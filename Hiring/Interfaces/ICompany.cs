using Hiring.Models;

namespace Hiring.Interfaces
{
    public interface ICompany:IDisposable
    {
        Task<object> addCompany(string companyEmail, string companyPassword, string companyName, string companyNumber);
        Task<Company> getCompany(int companyId);
        Task deleteCompany(int companyId);
        Task<object> signin(string companyEmail, string companyPassword);
        Task<List<Employee>> getCompanyEmployees(int companyId);
        int getCurrentCompanyId();
    }
}
