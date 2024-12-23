using AutoMapper;
using Hiring.dtos;
using Hiring.Models;
using Hiring.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using MailKit.Net.Smtp;
using MimeKit;

namespace Hiring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly CvService _cvService;

        public EmployeeController(EmployeeService employeeService, IMapper mapper, CvService cvService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _cvService = cvService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<SigningResponse>> signup([FromBody] SignUpInfo userInfo)
        {
            return Ok(await _employeeService.signup(userInfo));
        }

        [HttpPost("signin")]
        public async Task<ActionResult<SigningResponse>> signin(string email,string password)
        {
            return Ok(await _employeeService.signin(email, password));
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> getEmployee(int employeeId)
        {
            return Ok(_mapper.Map<EmployeeDto>(await _employeeService.getEmployee(employeeId)));
        }

        [HttpPut("uploadCv")]
        public async Task<ActionResult<CV>> uploadCv([FromForm]UploadCv cv, [FromForm] int employeeId)
        {
            return Ok(await _employeeService.uploadCvForEmployee(employeeId, cv));
        }

        [HttpPut("JoinToCompany")]
        public async Task<ActionResult> JoinToCompany(int employeeId,int companyId)
        {
            await _employeeService.joinToCompany(employeeId,companyId);
            return Ok();
        }

        //[HttpPost("sendEmail")]
        //public async Task SendEmailAsync(string toEmail, string subject, string body)
        //{

        //    var message = new MimeMessage();
        //    message.From.Add(new MailboxAddress("ammar", "Aalanany09@gmail.com"));
        //    message.To.Add(new MailboxAddress("", toEmail));
        //    message.Subject = subject;

        //    var bodyBuilder = new BodyBuilder { TextBody = body }; // For plain text, use TextBody
        //    message.Body = bodyBuilder.ToMessageBody();

        //    using (var client = new MailKit.Net.Smtp.SmtpClient())
        //    {
        //        await client.ConnectAsync("smtp.your-email-provider.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        //        await client.AuthenticateAsync("your-email@example.com", "your-email-password");
        //        await client.SendAsync(message);
        //        await client.DisconnectAsync(true);
        //    }
        //}

    }
}
