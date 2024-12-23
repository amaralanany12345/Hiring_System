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
    public class EducationController : ControllerBase
    {
        private readonly EducationService _educationService;
        private readonly IMapper _mapper;

        public EducationController(EducationService educationService, IMapper mapper)
        {
            _educationService = educationService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<ActionResult<Education>> addEducation(int employeeId, string educationalInstitute, DateTime StartDate, DateTime endDate, string description)
        {
            return Ok(await _educationService.AddEducation(employeeId, educationalInstitute, StartDate, endDate, description));
        }
        
        [HttpGet]
        public async Task<ActionResult<Education>> getEducation(int employeeId, int educationId)
        {
            return Ok(await _educationService.getEmployeeEducation(employeeId,educationId));
        }

        [HttpGet("AllEmployeeEducations")]
        public async Task<ActionResult<List<Education>>> getAllEmployeeEducations(int employeeId)
        {
            return Ok(await _educationService.getAllEmployeeEducations(employeeId));
        }

        [HttpDelete]
        public async Task<ActionResult> deleteEmployeeEducation(int employeeId,int educationId)
        {
            await _educationService.deleteEmployeeEducation(employeeId, educationId);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Education>> updateEducation(int employeeId, int educationId, string educationalInstitute, DateTime startDate, DateTime endDate, string description)
        {
            return Ok(await _educationService.updateEmployeeEducation(employeeId, educationId, educationalInstitute, startDate, endDate, description));
        }

    }
}
