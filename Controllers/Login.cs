using System;
using AutoMapper;
using System.Linq;
using EightAnd_Backend.Dtos;
using System.Threading.Tasks;
using EightAnd_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using EightAnd_Backend.Services;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using EightAnd_Backend.Services.Databases;

namespace EightAnd_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Login : ControllerBase
    {
        private readonly LoginService _loginData;
        private readonly IMapper _mapper;

        private readonly DataContext _DbLogin;
        public Login(LoginService loginData, IMapper mapper, DataContext DbLogin)
        {
            _loginData = loginData;
            _mapper = mapper;
            _DbLogin = DbLogin;
        }

        [Authorize]
        [HttpGet("allAccounts")]
        public IEnumerable<CreateAcctModel> GetAllLogins()
        {
            return _loginData.GetLoginInfo();
        }

        [Authorize]
        [HttpGet("{email}")]
        public ActionResult <loginDto> GetUser(string email)
        {
            var loginItem = _DbLogin.UserInfoSql.FirstOrDefault(e => e.Email == email);
            
            if(loginItem != null){
                return Ok(_mapper.Map<loginDto>(loginItem));
            }
            return NotFound();
        }

        [HttpPost("addUser")]
        public bool AddUserinfo(CreateAcctModel User)
        {
            return _loginData.AddUserInfo(User);
        }

        [HttpDelete("deleteLogin/{email}")]
        public ActionResult DeleteLogin(string email)
        {
            var emailFromRepo = _DbLogin.UserInfoSql.FirstOrDefault(e => e.Email == email);
            if (emailFromRepo == null)
            {
                return NotFound();
            }
            _loginData.DeleteEmail(emailFromRepo);
            return NoContent();
            
        }
    }
}