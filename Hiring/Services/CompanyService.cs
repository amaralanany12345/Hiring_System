using Hiring.Interfaces;
using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Hiring.Services
{
    public class CompanyService :SigningService, ICompany
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public CompanyService(AppDbContext context, IHttpContextAccessor contextAccessor,Jwt jwt):base(jwt)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<object> addCompany(string companyEmail,string companyPassword,string companyName, string companyNumber)
        {
            var company = new Company();
            company.compnanyName = companyName;
            company.companyNumber = companyNumber;
            company.companyEmail = companyEmail;
            company.companyPassword = hashPassword(companyPassword);
            _context.companies.Add(company);
            await _context.SaveChangesAsync();
            return new
            {
                Company = company,
                toekn=generateToken(company.id),
            };
        }

        public async Task deleteCompany(int companyId)
        {
            var company = await getCompany(companyId);
            _context.companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Company> getCompany(int companyId)
        {
            var company = await _context.companies.Where(a => a.id == companyId).FirstOrDefaultAsync();
            if (company == null)
            {
                throw new ArgumentException("company is not found");
            }
            return company;
        }

        public async Task<List<Employee>> getCompanyEmployees(int companyId)
        {
            var company=await getCompany(companyId);
            var companyEmployee=await _context.employees.Where(a=>a.companyId == companyId).ToListAsync();
            return companyEmployee;
        }

        public int getCurrentCompanyId()
        {
            if (_contextAccessor?.HttpContext?.User == null)
            {
                throw new ArgumentException("context accessor is not found");
            }
            var stringCompanyId =_contextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            if (stringCompanyId==null)
            {
                throw new ArgumentException("company id is not found");
            }
            return int.Parse(stringCompanyId);
        }

        public async Task<object> signin(string companyEmail, string companyPassword )
        {
            var company=await _context.companies.Where(a=>a.companyEmail == companyEmail).FirstOrDefaultAsync();
            if (company == null || !verifyPassword(companyPassword,company.companyPassword))
            {
                throw new ArgumentException("company is not found");
            }
            return new { 
                company=company,
                token=generateToken(company.id) };
        }
    }
}
