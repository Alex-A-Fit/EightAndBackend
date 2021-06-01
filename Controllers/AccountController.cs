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
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountservice;
        private readonly DataContext _DbContext;
        private readonly IMapper _mapper;

        public AccountController(AccountService accountservice, DataContext DbContext, IMapper mapper)
        {
            _accountservice = accountservice;
            _DbContext = DbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<AccountInfoDto> SearchAccts()
        {
            var Accts = _accountservice.GetAcctInfo().ToList();

            return Ok(_mapper.Map<IList<AccountInfoDto>>(Accts));

        }

        [HttpGet("{email}")]
        public ActionResult<AccountInfoDto> GetUser(string email)
        {
            var accountItem = _DbContext.UserInfoSql.FirstOrDefault(e => e.Email == email);

            if (accountItem != null)
            {
                return Ok(_mapper.Map<AccountInfoDto>(accountItem));
            }
            return NotFound();
        }

        [HttpPost("update/addGroup/{email}/{groups}")]
        public ActionResult AcctAddGroups(string email, string groups)
        {
            //verify email Exists
            var emailFromRepo = _DbContext.UserInfoSql.FirstOrDefault(e => e.Email == email);
            if (emailFromRepo == null)
            {
                return NotFound();
            }
            emailFromRepo.GroupsInvolved += groups + " | ";
            _DbContext.SaveChanges();
            return NoContent();
        }
        [HttpPost("update/removeGroup/{email}/{group}")]
        public ActionResult AcctRemoveGroups(string email, string group)
        {
            //verify email Exists
            var emailFromRepo = _DbContext.UserInfoSql.FirstOrDefault(e => e.Email == email);
            if (emailFromRepo == null)
            {
                return NotFound();
            }
            var removeGroup = group + " | ";
            emailFromRepo.GroupsInvolved = emailFromRepo.GroupsInvolved.Replace(removeGroup, "");
            _DbContext.SaveChanges();
            return Ok();
        }

        [HttpPost("update/removeEvent/{email}/{events}")]
        public ActionResult RemoveGroup(string email, string events)
        {
            var emailFromRepo = _DbContext.UserInfoSql.FirstOrDefault(e => e.Email == email);
            if (emailFromRepo == null)
            {
                return NotFound();
            }
            var removeEvent = events + " | ";
            emailFromRepo.EventsInvolved = emailFromRepo.EventsInvolved.Replace(removeEvent, "");
            _DbContext.SaveChanges();
            return Ok();
        }

        
        [HttpPost("update/addEvent/{email}/{events}")]
        public ActionResult UpdateAcctEvents(string email, string events)
        {
            //verify email Exists
            var emailFromRepo = _DbContext.UserInfoSql.FirstOrDefault(e => e.Email == email);
            if (emailFromRepo == null)
            {
                return NotFound();
            }
            emailFromRepo.EventsInvolved += events + " | ";
            _DbContext.SaveChanges();
            return NoContent();
        }
     

        [HttpPut("updateFavorites/{email}")]
        public ActionResult UpdateAcctFavs(string email, FavoriteDto updateFavDto)
        {
            //verify email Exists
            var emailFromRepo = _DbContext.UserInfoSql.FirstOrDefault(e => e.Email == email);
            if (emailFromRepo == null)
            {
                return NotFound();
            }
             _mapper.Map(updateFavDto, emailFromRepo);
            _DbContext.SaveChanges();
            return NoContent();
        }

       


    }
}