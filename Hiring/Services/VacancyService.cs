using Hiring.Interfaces;
using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Linq.Expressions;

namespace Hiring.Services
{
    public class VacancyService : IVacancy
    {
        private readonly AppDbContext _context;
        private readonly CompanyService _companyService;
        private readonly EmployeeService _employeeService;

        public VacancyService(AppDbContext context, CompanyService companyService, EmployeeService employeeService)
        {
            _context = context;
            _companyService = companyService;
            _employeeService = employeeService;
        }

        public async Task<Vacancy> addVacancy(int companyId, string title, string description, int yearsOfExperience, int salary, List<string> vacancySkills)
        {
            //if (_companyService.getCurrentCompanyId() != companyId)
            //{
            //    throw new ArgumentException("you are not allowed to access this route");
            //}
            Console.WriteLine("ammar");
            var company =await _companyService.getCompany(companyId);
            var vacancy=new Vacancy().setCompany(company).setCompanyId(companyId)
                .setTitle(title).setDescription(description).setYearsOfExperience(yearsOfExperience).setSalary(salary).setSkills(vacancySkills);
            _context.vacancies.Add(vacancy);
            await _context.SaveChangesAsync();
            return vacancy;
        }

        public async Task<EasyApply> applyForVacancy(int vacancyId, int employeeId,string coverLetter)
        {
            var vacancyApplyFor = await getVacancy(vacancyId);
            var employeeApplied=await _employeeService.getEmployee(employeeId);
            var easyApply = new EasyApply();
            easyApply.employee = employeeApplied;
            easyApply.employeeId = employeeId;
            easyApply.vacancy = vacancyApplyFor;
            easyApply.vacancyId = vacancyId;
            easyApply.employeeCv = employeeApplied.employeeCv;
            //easyApply.employeeCvId = employeeApplied.employeeCvId;
            var employeeVacancy = new EmployeeVacancies();
            employeeVacancy.employeeId = employeeId;
            employeeVacancy.employee = employeeApplied;
            employeeVacancy.vacancyId = vacancyId;
            employeeVacancy.vacancy=vacancyApplyFor;
            vacancyApplyFor.appliedEmployees.Add(employeeVacancy);
            _context.employeeVacancies.Add(employeeVacancy);
            await _context.SaveChangesAsync();
            return easyApply;
            
        }
        public async Task deleteVacancy(int vacancyId)
        {
            var vacancy = await getVacancy(vacancyId);
            if (_companyService.getCurrentCompanyId() != vacancy.companyId)
            {
                throw new ArgumentException("you are not allowed to access this route");
            }
            _context.vacancies.Remove(vacancy);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Vacancy>> getAllCompanyVacancies(int companyId)
        {
            var companyVacancies = await _context.vacancies.Where(a=>a.companyId==companyId).ToListAsync();
            return companyVacancies;
        }
        public async Task<List<Vacancy>> getAllVacancies()
        {
            var vacancies =await _context.vacancies.ToListAsync();
            return vacancies;
        }


        public async Task<Vacancy> getVacancy(int vacancyId)
        {
            var vacancy=await _context.vacancies.Where(a=>a.id==vacancyId).FirstOrDefaultAsync();

            if (vacancy == null)
            { 
                throw new NotImplementedException("vacancy is not found");
            }
            return vacancy;
        }
    }
}
