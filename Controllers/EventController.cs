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
    public class EventController : ControllerBase
    {
        private readonly EventService _eventservice;
        private readonly DataContext _DbContext;
        private readonly IMapper _mapper;

        public EventController(EventService eventservice, DataContext DbContext, IMapper mapper)
        {
            _eventservice = eventservice;
            _DbContext = DbContext;
            _mapper = mapper;
        }
       
       [HttpGet]
       public IEnumerable<EventInfoModel> GetEvents()
       {
           return _eventservice.GetEvents();
       }

       [HttpPost("addEvent")]
        public bool AddEvent(EventInfoModel newEvent)
        {
            return _eventservice.AddEvent(newEvent);
        }

        [HttpDelete("{eventId}")]
        public ActionResult DeleteEvent(int eventId)
        {
            var eventFromGroup = _DbContext.EventNfoSql.FirstOrDefault(e => e.Id == eventId);
             if (eventFromGroup == null)
            {
               return NotFound();
            }
            _eventservice.DeleteEvent(eventFromGroup);
            return NoContent();
        }

        
    }
}