using Hiring.Interfaces;
using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace Hiring.Services
{
    public class EmployeeService : SigningService,IEmployee
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly CvService _cvService;
        private readonly CompanyService _companyService;

        public EmployeeService(AppDbContext context, Jwt jwt, IHttpContextAccessor contextAccessor, CvService cvService, CompanyService companyService) : base(jwt)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _cvService = cvService;
            _companyService = companyService;
        }

        public async Task<SigningResponse> signin(string email, string password)
        {
            var employee = await _context.employees.Where(a => a.email == email).FirstOrDefaultAsync();
            if(employee==null || !(verifyPassword(password, employee.password)))
            {
                throw new ArgumentException("employee is not found");
            }
            return new SigningResponse {
                user=employee,
                token=generateToken(employee.id),
            };
        }

        public async Task<SigningResponse> signup(SignUpInfo userInfo)
        {
            var employee = new Employee();
            employee.name = userInfo.name;
            employee.email = userInfo.email;
            employee.password = hashPassword(userInfo.password);
            employee.phone = userInfo.phone;
            employee.age = userInfo.age;
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();
            return new SigningResponse
            {
                user = employee,
                token = generateToken(employee.id),
            };
        }

        public async Task<Employee> getEmployee(int employeeId) 
        {
            var employee=await _context.employees.Where(a => a.id == employeeId).FirstOrDefaultAsync();
            if (employee == null)
            {
                throw new ArgumentException("employee is not found");
            }
            return employee;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int getCurrentEmployeeId()
        {
            if(_contextAccessor?.HttpContext?.User== null)
            {
                throw new ArgumentException("context accessor is not found");
            }
            var employeeId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            if(employeeId == null)
            {
                throw new ArgumentException("employee id is not found ");
            }
            return int.Parse(employeeId);
        }

        public async Task<CV> uploadCvForEmployee(int employeeId, UploadCv cv)
        {
            var employee=await getEmployee(employeeId);
            var newCv = new CV();
            newCv = await _cvService.uploadCv(cv);
            newCv.employee = employee;
            newCv.employeeId = employeeId;
            _context.CVS.Add(newCv);
            await _context.SaveChangesAsync();
            employee.employeeCv = newCv;
            employee.employeeCvId = newCv.id;
            await _context.SaveChangesAsync();
            return newCv;
        }

        public async Task joinToCompany(int employeeId, int companyId)
        {
            //if(getCurrentEmployeeId() != employeeId)
            //{
            //    throw new ArgumentException("you are not allowed to access this route");
            //}
            var employee=await getEmployee(employeeId);
            var company=await _companyService.getCompany(companyId);
            employee.company = company;
            employee.companyId = companyId;
            await _context.SaveChangesAsync();
            company.companyEmployees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}
