using Hiring.Models;

namespace Hiring.Interfaces
{
    public interface IEmployee:IDisposable
    {
        Task<SigningResponse> signin(string email, string password);
        Task<SigningResponse> signup(SignUpInfo userInfo);
        Task<Employee> getEmployee(int employeeId);
        Task<CV> uploadCvForEmployee(int employeeId,UploadCv cv);
        Task joinToCompany(int employeeId,int companyId);
    }
}
