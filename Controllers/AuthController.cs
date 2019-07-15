using Microsoft.AspNetCore.Mvc;
using Excelsior.API.Data;
using System.Threading.Tasks;
using Excelsior.API.Models;
using Excelsior.API.Dtos;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Excelsior.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository _repo;
         private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration= configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto) 
        {   
            if(!string.IsNullOrEmpty( userForRegisterDto.PanNo))
                userForRegisterDto.PanNo = userForRegisterDto.PanNo.ToUpper();

            if(await _repo.UserExist(userForRegisterDto.PanNo)) {
                return BadRequest("PAN No. already Exist");
            }

            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
                     
            var userToCreate = new User {
                PanNo = userForRegisterDto.PanNo,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                MobNo = userForRegisterDto.MobNo,
                Email = userForRegisterDto.EmailID
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
             
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto) {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            userForLoginDto.PanNo = userForLoginDto.PanNo.ToUpper();
            
            var userFromRepo = await _repo.Login(userForLoginDto.PanNo, userForLoginDto.Password);

            if(userFromRepo == null)
                return Unauthorized();
            
             //generating token
            var tokenHandler= new JwtSecurityTokenHandler();
            var key= Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject= new ClaimsIdentity(new Claim[]
                {
                   new Claim(ClaimTypes.NameIdentifier,userFromRepo.UserId.ToString()),
                   new Claim(ClaimTypes.Name, userFromRepo.PanNo)     
                }),
                Expires= DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature)
            };

            var token= tokenHandler.CreateToken(tokenDescriptor);
            var tokenString=tokenHandler.WriteToken(token);

             return Ok(new {tokenString,userFromRepo});

        }

    }
}