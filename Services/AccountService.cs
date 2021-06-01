using System;
using System.Linq;
using EightAnd_Backend.Models;
using System.Collections.Generic;
using EightAnd_Backend.Services.Databases;

namespace EightAnd_Backend.Services
{
    public class AccountService
    {
        private readonly DataContext _DbContext;
        public AccountService(DataContext DbContext )
        {
            _DbContext = DbContext;
        }
       
       public IEnumerable <CreateAcctModel> GetAcctInfo()
        {
            return _DbContext.UserInfoSql;
        }
    }
}