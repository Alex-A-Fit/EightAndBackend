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
using Microsoft.AspNetCore.Cors;

namespace EightAnd_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _groupInfo;
        private readonly DataContext _Dbgroups;
        private readonly IMapper _mapper;

        public GroupController(GroupService groupInfo, DataContext DbGroups, IMapper mapper)
        {
            _groupInfo = groupInfo;
            _Dbgroups = DbGroups;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<GroupInfoModel> GetGroups()
        {
            return _groupInfo.GetGroupAccts();
        }
        
        [HttpGet("{companyName}")]
        public ActionResult <GroupDto> GetGroup(string companyName)
        {
            var group = _Dbgroups.GroupNfoSql.FirstOrDefault(e => e.CompanyName == companyName);
            
            if(group != null){
                return Ok(_mapper.Map<GroupDto>(group));
            }
            return NotFound();
        }

        [HttpGet("search")]
        public ActionResult <GroupSearchDto> SearchGroups(string searchGroups)
        {      
            var groups = _groupInfo.GetGroupAccts().ToList();

            return Ok(_mapper.Map<IList<GroupSearchDto>>(groups));      
           
        }

        [HttpPost("addGroup")]
        public bool AddGroup(GroupInfoModel newGroup)
        {
            return _groupInfo.AddGroup(newGroup);
        }

        [HttpPut("updateGroup/{companyName}")]
        public ActionResult UpdateGroup(string companyName, GroupDto updateGroupDto)
        {
            //verify companyName Exists
            var GroupFromRepo = _Dbgroups.GroupNfoSql.FirstOrDefault(e => e.CompanyName == companyName);
            if (GroupFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(updateGroupDto, GroupFromRepo);
            _Dbgroups.SaveChanges();
            return NoContent();
        }

        [HttpDelete("deleteGroup/{companyName}")]
        public ActionResult DeleteGroup(string companyName)
        {
            var GroupFromRepo = _Dbgroups.GroupNfoSql.FirstOrDefault(e => e.CompanyName == companyName);
            if (GroupFromRepo == null)
            {
                return NotFound();
            }
            _groupInfo.DeleteGroup(GroupFromRepo);
            return NoContent();
            
        }

    }
}