using AutoMapper;
using Hiring.dtos;
using Hiring.Enums;
using Hiring.Models;
using Hiring.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeVacancyController : ControllerBase
    {
        private readonly EmployeeVacancyService _employeeVacancyService;

        public EmployeeVacancyController(EmployeeVacancyService employeeVacancyService)
        {
            _employeeVacancyService = employeeVacancyService;
        }

        [HttpGet("AllEmployeesAppliedForVacancy")]
        public async Task<ActionResult<List<Employee>>> getAllEmployeesAppliedForVacancy(int vacancyId)
        {
            return Ok(await _employeeVacancyService.getAllEmployeesAppliedForVacancy(vacancyId));
        }

        [HttpGet("AllEmployeesAcceptedForVacancy")]
        public async Task<ActionResult<List<Employee>>> AllEmployeesAcceptedForVacancy(int vacancyId)
        {
            return Ok(await _employeeVacancyService.getAllEmployeesAcceptedForVacancy(vacancyId));
        }

        [HttpGet("AllEmployeesRejectedForVacancy")]
        public async Task<ActionResult<List<Employee>>> AllEmployeesRejectedForVacancy(int vacancyId)
        {
            return Ok(await _employeeVacancyService.getAllEmployeesRejectedForVacancy(vacancyId));
        }

        [HttpGet("AllEmployeesViewedForVacancy")]
        public async Task<ActionResult<List<Employee>>> AllEmployeesViewedForVacancy(int vacancyId)
        {
            return Ok(await _employeeVacancyService.getAllEmployeesViewedForVacancy(vacancyId));
        }

        [HttpGet("AppliedEmployeeState")]
        public async Task<ActionResult<EmployeeVacancies>> getAppliedEmployeeState(int vacancyId, int employeeId)
        {
            return Ok(await _employeeVacancyService.getAppliedEmployeeState(vacancyId,employeeId));
        }

        [HttpPut]
        public async Task<ActionResult<EmployeeVacancies>> updateAppliedEmployeeState(int vacancyId, int employeeId, VacancyState employeeVacancyState)
        {
            return Ok(await _employeeVacancyService.updateAppliedEmployeeState(vacancyId,employeeId, employeeVacancyState));
       }

    }
}
