using System;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using EightAnd_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using EightAnd_Backend.Services;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using EightAnd_Backend.Services.Databases;

namespace EightAnd_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Auth : ControllerBase
    {
        
        private readonly LoginService _login;
        private readonly DataContext _loginData;
        public Auth(LoginService login, DataContext loginData)
        {
            _login = login;
            _loginData = loginData;
        }

        [HttpPost, Route("login")]
         public IActionResult Login([FromBody] LoginModel user)
         {
             var UserExists = _loginData.UserInfoSql.FirstOrDefault(e => e.Email == user.Email && e.Password == user.Password);
              if(UserExists != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
         }
    }
}