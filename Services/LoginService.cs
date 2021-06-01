using System.Linq;
using EightAnd_Backend.Dtos;
using EightAnd_Backend.Models;
using System.Collections.Generic;
using EightAnd_Backend.Services.Databases;
using System;

namespace EightAnd_Backend.Services
{
    public class LoginService
    {
         
        private readonly DataContext _DbLogin;
        public LoginService(DataContext DbLogin )
        {
            _DbLogin = DbLogin;
        }
       
        public IEnumerable <CreateAcctModel> GetLoginInfo()
        {
            return _DbLogin.UserInfoSql;
        }

        public bool AddUserInfo(CreateAcctModel User)
        {
            var UserExists = _DbLogin.UserInfoSql.FirstOrDefault(e => e.Email == User.Email);
            if(UserExists != null){
                return false;
            }
            else{
            User.Confirmed = true;
            _DbLogin.Add(User);
            int usersAdded = _DbLogin.SaveChanges();
            return usersAdded > 0;
            }
        }
         public void DeleteEmail(CreateAcctModel group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            _DbLogin.Remove(group);
            _DbLogin.SaveChanges();
        }
    }
}