using Hiring.Models;
using Hiring.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly VacancyService _vacancyService;
        public VacancyController(VacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpPost]
        public async Task<ActionResult<Vacancy>> addVacancy(int companyId, string title,
            string description, int yearsOfExperience, int salary, [FromBody] List<string> vacancySkills)
        {
            Console.WriteLine(vacancySkills.Count);
            return Ok(await _vacancyService.addVacancy(companyId,title,description,yearsOfExperience,salary,vacancySkills));
        }

        [HttpGet("vacancy")]
        public async Task<ActionResult<Vacancy>> getVacancy(int vacancyId)
        {
            return Ok(await _vacancyService.getVacancy(vacancyId));
        }

        [HttpGet("AllCompanyVacancies")]
        public async Task<ActionResult<List<Vacancy>>> getAllCompanyVacancies(int companyId)
        {
            return Ok(await _vacancyService.getAllCompanyVacancies(companyId));
        }

        [HttpGet("AllVacancies")]
        public async Task<ActionResult<List<Vacancy>>> getAllVacancies()
        {
            return Ok(await _vacancyService.getAllVacancies());
        }
        
        [HttpDelete]
        public async Task<ActionResult> deleteVacancy(int vacancyId)
        {
            await _vacancyService.deleteVacancy(vacancyId);
            return Ok();
        }

        [HttpPut("applyForVacancy")]
        public async Task<ActionResult<EasyApply>> applyForVacancy(int vacancyId, int employeeId, string coverLetter)
        {
            return Ok(await _vacancyService.applyForVacancy(vacancyId,employeeId,coverLetter));
        }
    }
}
