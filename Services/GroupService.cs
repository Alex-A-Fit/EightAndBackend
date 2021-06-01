using System;
using System.Linq;
using EightAnd_Backend.Models;
using System.Collections.Generic;
using EightAnd_Backend.Services.Databases;

namespace EightAnd_Backend.Services
{
    public class GroupService
    {
        private readonly DataContext _DbGroups;

        public GroupService( DataContext DbGroups)
        {
            _DbGroups = DbGroups;
        }

        public IEnumerable<GroupInfoModel> GetGroupAccts()
        {
            return _DbGroups.GroupNfoSql;
        }
        public bool AddGroup(GroupInfoModel group)
        {
            var GroupExists = _DbGroups.GroupNfoSql.FirstOrDefault(grp => grp.CompanyName == group.CompanyName);
            if(GroupExists != null)
            {
                return false;
            }
            else
            {
                if(group.SavedForLater == true)
                {
                    string expireDate = DateTime.Now.AddDays(7).ToString("d");
                    group.ExpirationDate = expireDate;
                }
                _DbGroups.Add(group);
                int groupAdded = _DbGroups.SaveChanges();
                return groupAdded > 0;
            }
        }
        public void DeleteGroup(GroupInfoModel group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            _DbGroups.Remove(group);
            _DbGroups.SaveChanges();
        }

        
    }
}