using Microsoft.AspNetCore.Mvc;
using Excelsior.API.Data;
using System.Threading.Tasks;
using Excelsior.API.Models;
using System.Net;
using System.Net.Mail;

namespace Excelsior.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IAuthRepository _repo;
        private readonly string tomail = "Narendra_Dharmadhikari@excelsiorindia.in";
        private readonly string tomailName = "Narendra Dharmadhikari";
        public ContactController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("message")]
        public async Task<IActionResult> Message([FromBody]Message msg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _repo.SendMessage(msg);

                var fromAddress = new MailAddress("sharayu_nalavade@excelsiorindia.in","sharayu");
                var toAddress = new MailAddress(tomail, tomailName);
                string fromPassword = "anilramchandra@66";
                string subject = msg.sub;
                string body = "You have received an Enqiry From "+ msg.FirstName + " "+msg.LastName+ ".\n"
                            +"Details: \n Email:- "+ msg.From +"\n" + "Message:- " + msg.msg;

                var smtp = new SmtpClient
                {
                    Host = "us2.smtp.mailhostbox.com",
                    Port = 25,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                return Ok();
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex);
            }

        }
    }
}