using System;
using System.Linq;
using EightAnd_Backend.Models;
using System.Collections.Generic;
using EightAnd_Backend.Services.Databases;
using Microsoft.AspNetCore.Mvc;

namespace EightAnd_Backend.Services
{
    public class EventService
    {
        private readonly DataContext _DbContext;
        public EventService( DataContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IEnumerable<EventInfoModel> GetEvents()
        {
            return _DbContext.EventNfoSql;
        }

        public bool AddEvent(EventInfoModel newEvent)
        {
                _DbContext.Add(newEvent);
                int eventAdded = _DbContext.SaveChanges();
                return eventAdded > 0;
        }
        public void DeleteEvent(EventInfoModel eventDeleted)
        {
             if (eventDeleted == null)
            {
                throw new ArgumentNullException(nameof(eventDeleted));
            }
            _DbContext.Remove(eventDeleted);
            _DbContext.SaveChanges();
        }
    }
}