namespace EightAnd_Backend.Dtos
{
    public class AccountInfoDto
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string GroupsInvolved {get; set;} = "";
        public string EventsInvolved {get; set;} = "";
        public string FavoriteGroups {get; set;} = "";
    }
}