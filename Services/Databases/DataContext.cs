using EightAnd_Backend.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace EightAnd_Backend.Services.Databases
{
    public class DataContext : DbContext
    {
        public DbSet<CreateAcctModel> UserInfoSql {get; set;}
        public DbSet<LoginModel> LoginNfoSql {get; set;}
        public DbSet<GroupInfoModel> GroupNfoSql {get; set;}
        public DbSet<EventInfoModel> EventNfoSql {get; set;}

        public DataContext (DbContextOptions<DataContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            LoginSeed(builder);
        }
        private void LoginSeed(ModelBuilder builder)
        {
            var fixedAccountData = new List<CreateAcctModel>()
            {
            new CreateAcctModel(1, "Joe", "Mama", "222-888-6969", "yoMama@Gmail.com", "Admin", "yoDaddysSon"){},
            new CreateAcctModel(2, "Deez", "Crips", "209-435-2308", "Norte@Gmail.com", "Member",  "SupFoo"){},
            new CreateAcctModel(3, "Joes", "Family", "848-888-6999", "yoSpunk@Gmail.com", "Client",  "ComeOver;)"){},
            };

            var fixedLoginData = new List<LoginModel>()
            {
            new LoginModel(1, "yoMama@Gmail.com", "yoDaddysSon"){},
            new LoginModel(2, "Norte@Gmail.com", "SupFoo"){},
            new LoginModel(3, "yoSpunk@Gmail.com", "ComeOver;)"){},
            };

            var fixedGroupInfo = new List<GroupInfoModel>()
            {
                new GroupInfoModel(1, "Ability Unlimited", "New Delhi India", "222-888-8888", "AbilityUnlimited@gmail.com", null, "", "", "New Upcoming Indian Dance Group", "Jateen Bhakta", true, true, false){},
                new GroupInfoModel(2, "Abby Lee Dance Co", "Los Angeles, CA", "666-555-2332", "AbbyLee@yahoo.com", null, "", "", "New Upcoming Indian Dance Group", "Abby Miller", true, true, false){},
                new GroupInfoModel(3, "American Ballet Theatre", "New York City, NY", "456-789-1234", "ABC@gmail.com", null, "", "", "New Upcoming Indian Dance Group", "Mikhail Mordkin", false, true, false){},
            };

            var fixedEventData = new List<EventInfoModel>()
            {
                new EventInfoModel(1, 1, "Ability Unlimited", "San Francisco", "Splif", "06/21/21", "5:00 PM", 12, "06/10/21", "Lets get jiggy and dance to the beat of the drum", true, false),
                new EventInfoModel(2, 2, "Abby Lee Dance Co", "4415 ISwearthisIsReal Seattle, Wa", "SICKDOPEROPE", "07/31/21", "2:00 PM", 4, "06/1/21", "THIS will be a RAD JAZZ PARTY", false, false),
                new EventInfoModel(3, 3, "American Ballet Theatre", "San Francisco", "SHAISTA", "08/04/21", "9:00 AM", 27, "06/10/21", "Improv dance shenanigans", false, true)
            };


            builder.Entity<CreateAcctModel>().HasData(fixedAccountData);

            builder.Entity<LoginModel>().HasData(fixedLoginData);
            
            builder.Entity<GroupInfoModel>().HasData(fixedGroupInfo);
            
            builder.Entity<EventInfoModel>().HasData(fixedEventData);
        }
      
    }
}