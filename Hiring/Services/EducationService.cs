using Hiring.Interfaces;
using Hiring.Models;
using Microsoft.EntityFrameworkCore;

namespace Hiring.Services
{
    public class EducationService : IEducation
    {
        private readonly AppDbContext _context;
        private readonly EmployeeService _employeeService;

        public EducationService(AppDbContext context,EmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public async Task<Education> AddEducation(int employeeId, string educationalInstitute, DateTime StartDate, DateTime endDate, string description)
        {
            if (_employeeService.getCurrentEmployeeId() != employeeId)
            {
                throw new ArgumentException("you are not allowed to access this route");
            }

            var employee = await _employeeService.getEmployee(employeeId);
            var education = new Education().setEmployee(employee).setEmployeeId(employeeId).setDescription(description)
                .setEducationalInstitute(educationalInstitute).setStartDate(StartDate).setEndDate(endDate).Build();
            _context.educations.Add(education);
            await _context.SaveChangesAsync();
            return education;
        }

        public async Task deleteEmployeeEducation(int employeeId, int educationId)
        {
            if (_employeeService.getCurrentEmployeeId() != employeeId)
            {
                throw new ArgumentException("you are not allowed to access this route");
            }

            var employee = await _employeeService.getEmployee(employeeId);
            var education =await getEmployeeEducation(employeeId,educationId);
            _context.educations.Remove(education);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Education> getEmployeeEducation(int employeeId, int educationId)
        {
            var employee = await _employeeService.getEmployee(employeeId);
            var education =await _context.educations.Where(a => a.id == educationId && a.employeeId == employeeId).FirstOrDefaultAsync();
            if(education == null)
            {
                throw new ArgumentException("education is not found");
            }
            return education;
        }

        public async Task<List<Education>> getAllEmployeeEducations(int employeeId)
        {
            var employee = await _employeeService.getEmployee(employeeId);
            var employeeEducations = await _context.educations.Where(a=>a.employeeId == employeeId).ToListAsync();
            return employeeEducations;

        }

        public async Task<Education> updateEmployeeEducation(int employeeId, int educationId, string educationalInstitute, DateTime startDate, DateTime endDate, string description)
        {
            if (_employeeService.getCurrentEmployeeId() != employeeId)
            {
                throw new ArgumentException("you are not allowed to access this route");
            }
            var employee=await _employeeService.getEmployee(employeeId);
            var education = await getEmployeeEducation(employeeId, educationId);
            education.setEducationalInstitute(educationalInstitute).setStartDate(startDate).setEndDate(endDate).setDescription(description);
            await _context.SaveChangesAsync();
            return education;

        }
    }
}
