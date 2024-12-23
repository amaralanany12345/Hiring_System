using AutoMapper;
using Hiring.dtos;
using Hiring.Models;
using Hiring.Models;
using Hiring.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class companyController : ControllerBase
    {
        private readonly CompanyService _companyService;
        private readonly IMapper _mapper;

        public companyController(CompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Company>> addCompany(string companyEmail, string companyPassword, string companyName,string companyNumber)
        {
            return Ok(await _companyService.addCompany(companyEmail, companyPassword, companyName, companyNumber));
        }
        [HttpPost("signin")]
        public async Task<ActionResult<object>> signin (string companyEmail, string companyPassword)
        {
            return Ok(await _companyService.signin(companyEmail, companyPassword));
        }

        [HttpGet]
        public async Task<ActionResult<Company>> getCompany(int companyId)
        {
            return Ok(await _companyService.getCompany(companyId));
        }

        [HttpDelete]
        public async Task<ActionResult> deleteCompany(int companyId)
        {
            await _companyService.deleteCompany(companyId);
            return Ok();
        }

        [HttpGet("CompanyEmployee")]
        public async Task<ActionResult<List<Employee>>> getCompanyEmployees(int companyId)
        {
            return Ok(await _companyService.getCompanyEmployees(companyId));
        }
    }
}
