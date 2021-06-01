using System;

namespace EightAnd_Backend.Models
{
    public class GroupInfoModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebUrl { get; set; } ="";
        public string Photo { get; set; } = "";
        public string Logo { get; set; } = "";
        public string Description { get; set; }
        public string Director { get; set; }
        public bool Roster { get; set; }
        // public bool InventoryStatus { get; set; }
        // public bool Favorite { get; set; }
        // public bool Joined { get; set; }
        public bool Pending { get; set; }
        public bool SavedForLater { get; set; }
        public string Admins { get; set; }
        public string EventLeads { get; set; } = "";
        public string GeneralMember { get; set; } = "";
        public string AllRoster {get; set;}
        public int RosterCount {get; set;} = 1;
        public string ExpirationDate { get; set; } = "";

        public string DateTime { get; set; } = System.DateTime.Today.ToString("d");

        public GroupInfoModel(){}

        public GroupInfoModel(
            int id, 
            string companyName, 
            string location,
            string phoneNumber,
            string email,
            string webUrl, 
            string photo,
            string logo,
            string description, 
            string director, 
            bool roster, 
            // bool inventoryStatus, 
            // bool favorite, 
            // bool joined, 
            bool pending,
            bool savedForLater
            )
        {
            Id = id;
            CompanyName = companyName;
            Location = location;
            PhoneNumber = phoneNumber;
            Email = email;
            WebUrl = webUrl;
            Photo = photo;
            Logo = logo;
            Description = description;
            Director = director;
            Roster = roster;
            Pending = pending;
            SavedForLater = savedForLater;
            Admins = director + " | ";
            AllRoster = director + " | ";
            // InventoryStatus = inventoryStatus;
            // Favorite = favorite;
            // Joined = joined;
        }
    }
}