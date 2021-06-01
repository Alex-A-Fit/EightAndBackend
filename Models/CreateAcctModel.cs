namespace EightAnd_Backend.Models
{
    public class CreateAcctModel
    {
         public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string PhoneNumber {get; set;}
        public string Email {get; set;}
        public string AccountType {get; set;}
        public string Password {get; set;}
        public string GroupsInvolved {get; set;} = "";
        public string EventsInvolved {get; set;} = "";
        public string FavoriteGroups {get; set;} = "";
        public bool Confirmed {get; set;} = false;
        public bool Delete {get; set;} = false;

        public CreateAcctModel(){}
        public CreateAcctModel(
            int id, 
            string firstName, 
            string lastName,
            string phoneNumber,
            string email,
            string accountType,
            string password){
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
                AccountType = accountType;
                Password = password;
            }
    }
}