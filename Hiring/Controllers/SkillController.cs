using AutoMapper;
using Hiring.Models;
using Hiring.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly SkillService _skillService;

        public SkillController(SkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> addSkill(int employeeId,string skillName)
        {
            return Ok(await _skillService.addSkill(employeeId, skillName));
        }

        [HttpGet]
        public async Task<ActionResult<Skill>> getEmployeeSkill(int employeeId, int skillId)
        {
            return Ok(await _skillService.getEmployeeSkill(employeeId, skillId));
        }

        [HttpGet("getAllEmployeeSkills")]
        public async Task<ActionResult<List<Skill>>> getAllEmployeeSkills(int employeeId)
        {
            return Ok(await _skillService.getAllEmployeeSkills(employeeId));
        }

        [HttpDelete]
        public async Task<ActionResult> deleteEmployeeSkill(int employeeId, int skillId)
        {
            await _skillService.deleteEmployeeSkill(employeeId, skillId);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Skill>> updateSkill(int employeeId, int skillId, string skillName)
        {
            return Ok(await _skillService.updateEmployeeSkill(employeeId,skillId,skillName));
        }
    }
}
