using AutoMapper;
using Hiring.dtos;
using Hiring.Models;
using Hiring.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly ExperienceService _experienceService;

        public ExperienceController(ExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpPost]
        public async Task<ActionResult<Experience>> addExperience(int employeeId, string companyName,DateTime startDate, DateTime endDate, string description)
        {
            return Ok(await _experienceService.addExperience(employeeId, companyName, startDate, endDate, description));
        }

        [HttpGet("employeeExperience")]
        public async Task<ActionResult<Experience>> getEmployeeExperience(int employeeId, int experienceId)
        {
            return Ok(await _experienceService.getEmployeeExperience(employeeId,experienceId));
        }

        [HttpGet("AllEmployeeExperiences")]
        public async Task<ActionResult<List<Experience>>> getAllEmployeeExperiences(int employeeId)
        {
            return Ok(await _experienceService.getAllEmployeeExperiences(employeeId));
        }

        [HttpDelete]
        public async Task<ActionResult> deleteEmployeeExperience(int employeeId, int experienceId)
        {
            await _experienceService.deleteExperience(employeeId, experienceId);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<Skill>> updateEmployeeExperience(int employeeId, int experienceId, string companyName, DateTime startDate, DateTime endDate, string description)
        {
            return Ok(await _experienceService.updateEmployeeExperience(employeeId, experienceId, companyName, startDate, endDate, description));
        }

    }
}
