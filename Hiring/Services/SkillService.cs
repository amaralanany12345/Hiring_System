using Hiring.Interfaces;
using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Hiring.Services
{
    public class SkillService : ISkill
    {
        private readonly AppDbContext _context;
        private readonly EmployeeService _employeeService;
        public SkillService(AppDbContext context, EmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public async Task<Skill> addSkill(int employeeId, string skillName)
        {
            if (_employeeService.getCurrentEmployeeId() != employeeId) 
            {
                throw new ArgumentException("you are not allowed to access this route");
            }
            var employee=await _employeeService.getEmployee(employeeId);
            var skill=new Skill().setEmployee(employee).setEmployeeId(employeeId).setSkillName(skillName);
            _context.skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task deleteEmployeeSkill(int employeeId, int skillId)
        {
            if (_employeeService.getCurrentEmployeeId() != employeeId)
            {
                throw new ArgumentException("you are not allowed to access this route");
            }
            var skill=await getEmployeeSkill(employeeId,skillId);
            _context.skills.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Skill> getEmployeeSkill(int employeeId, int skillId)
        {
            var employeeSkill=await _context.skills.Where(a=>a.id==skillId && a.employeeId==employeeId).FirstOrDefaultAsync();
            if (employeeSkill == null)
            {
                throw new ArgumentException("employee Skill is not found");
            }
            return employeeSkill;
        }

        public async Task<List<Skill>> getAllEmployeeSkills(int employeeId)
        {
            var employeeSkill = await _context.skills.Where(a =>a.employeeId == employeeId).ToListAsync();
            return employeeSkill;
        }

        public async Task<Skill> updateEmployeeSkill(int employeeId, int skillId, string skillName)
        {
            if(_employeeService.getCurrentEmployeeId() != employeeId)
            {
                throw new ArgumentException("you are not allowed to access this route");
            }
            var employee=await _employeeService.getEmployee(employeeId);
            var skill=await getEmployeeSkill(employeeId, skillId);
            skill.setSkillName(skillName);
            await _context.SaveChangesAsync();
            return skill;
        }
    }
}
