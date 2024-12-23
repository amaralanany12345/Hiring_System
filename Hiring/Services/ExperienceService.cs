using Hiring.Interfaces;
using Hiring.Models;
using Microsoft.EntityFrameworkCore;

namespace Hiring.Services
{
    public class ExperienceService : IExperience
    {
        private readonly AppDbContext _context;
        private readonly EmployeeService _employeeService;

        public ExperienceService(AppDbContext context, EmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public async Task<Experience> addExperience(int employeeId, string companyName, DateTime startDate, DateTime endDate, string description)
        {
            if (_employeeService.getCurrentEmployeeId() != employeeId)
            {
                throw new ArgumentException("you are not allowed to access this route");
            }

            var employee = await _context.employees.Where(a => a.id == employeeId).FirstOrDefaultAsync();
            if (employee == null) {
                throw new ArgumentException("employee is not found");
            }
            var experience = new Experience().SetEmployee(employee).SetEmployeeId(employeeId).SetCompanyName(companyName).SetEndDate(endDate).SetStartDate(startDate).SetDescription(description);

            _context.experiences.Add(experience);
            await _context.SaveChangesAsync();
            return experience;
        }

        public async Task deleteExperience(int employeeId, int experienceId)
        {
            if (_employeeService.getCurrentEmployeeId() != employeeId)
            {
                throw new ArgumentException("you are not allowed to access this route");
            }

            var experience=await getEmployeeExperience(employeeId, experienceId);
            _context.experiences.Remove(experience);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Experience> getEmployeeExperience(int employeeId, int experienceId)
        {
            var employeeExperience = await _context.experiences.Where(a=>a.employeeId==employeeId && a.id==experienceId).FirstOrDefaultAsync();
            if (employeeExperience == null) {
                throw new ArgumentException("employee experience is not found");
            }
            return employeeExperience;
        }

        public async Task<List<Experience>> getAllEmployeeExperiences(int employeeId)
        {
            var employeeExperiences = await _context.experiences.Where(a => a.employeeId == employeeId).ToListAsync();
            return employeeExperiences;

        }

        public async Task<Experience> updateEmployeeExperience(int employeeId, int experienceId, string companyName, DateTime startDate, DateTime endDate, string description)
        {
            if (_employeeService.getCurrentEmployeeId() != employeeId)
            {
                throw new ArgumentException("you are not allowed to access this route");
            }

            var experience = await getEmployeeExperience(employeeId, experienceId);
            experience.SetCompanyName(companyName).SetStartDate(startDate).SetEndDate(endDate).SetDescription(description);
            await _context.SaveChangesAsync();
            return experience;
        }
    }
}
