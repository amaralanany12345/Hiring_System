using Hiring.Enums;
using Hiring.Interfaces;
using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;

namespace Hiring.Services
{
    public class EmployeeVacancyService:IEmployeeVacancy
    {
        private readonly AppDbContext _context;
        private readonly VacancyService _vacancyService;
        private readonly EmployeeService _employeeService;
        public EmployeeVacancyService(AppDbContext context, VacancyService vacancyService, EmployeeService employeeService)
        {
            _context = context;
            _vacancyService = vacancyService;
            _employeeService = employeeService;
        }
        public async Task<List<Employee>> getAllEmployeesAppliedForVacancy(int vacancyId)
        {
            var vacancy = await _vacancyService.getVacancy(vacancyId);
            var employeesAppliedForVacancy = await _context.employeeVacancies.Where(a => a.vacancyId == vacancyId).ToListAsync();
            var employees=new List<Employee>();
            foreach (var item in employeesAppliedForVacancy) 
            {
                employees.Add(await _employeeService.getEmployee(item.employeeId));
            }
            return employees;
        }
        public async Task<List<Employee>> getAllEmployeesAcceptedForVacancy(int vacancyId)
        {
            var vacancy = await _vacancyService.getVacancy(vacancyId);
            var employeesAppliedForVacancy = await _context.employeeVacancies.Where(a => a.vacancyId == vacancyId && a.vacancyState==Enums.VacancyState.accepted).ToListAsync();
            var employees = new List<Employee>();
            foreach (var item in employeesAppliedForVacancy)
            {
                employees.Add(await _employeeService.getEmployee(item.employeeId));
            }
            return employees;
        }


        public async Task<List<Employee>> getAllEmployeesRejectedForVacancy(int vacancyId)
        {
            var vacancy = await _vacancyService.getVacancy(vacancyId);
            var employeesAppliedForVacancy = await _context.employeeVacancies.Where(a => a.vacancyId == vacancyId && a.vacancyState == Enums.VacancyState.rejected).ToListAsync();
            var employees = new List<Employee>();
            foreach (var item in employeesAppliedForVacancy)
            {
                employees.Add(await _employeeService.getEmployee(item.employeeId));
            }
            return employees;
        }

        public async Task<List<Employee>> getAllEmployeesViewedForVacancy(int vacancyId)
        {
            var vacancy = await _vacancyService.getVacancy(vacancyId);
            var employeesAppliedForVacancy = await _context.employeeVacancies.Where(a => a.vacancyId == vacancyId && a.vacancyState == Enums.VacancyState.viewed).ToListAsync();
            var employees = new List<Employee>();
            foreach (var item in employeesAppliedForVacancy)
            {
                employees.Add(await _employeeService.getEmployee(item.employeeId));
            }
            return employees;
        }

        public async Task<EmployeeVacancies> updateAppliedEmployeeState(int vacancyId, int employeeId,VacancyState employeeVacancyState)
        {
            var employeeAppliedForVacancy=await getAppliedEmployeeState(vacancyId, employeeId);
            employeeAppliedForVacancy.vacancyState = employeeVacancyState;
            await _context.SaveChangesAsync();
            return employeeAppliedForVacancy;
        }

        public async Task<EmployeeVacancies> getAppliedEmployeeState(int vacancyId, int employeeId)
        {
            var employeeAppliedForVacancy = await _context.employeeVacancies.Where(a => a.vacancyId == vacancyId && a.employeeId == employeeId).FirstOrDefaultAsync();
            if(employeeAppliedForVacancy == null)
            {
                throw new ArgumentException("employee Vacancy is not found");
            }
            return employeeAppliedForVacancy;

        }
    }
}
