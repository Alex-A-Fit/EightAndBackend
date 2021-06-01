namespace EightAnd_Backend.Models
{
    public class LoginModel
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}

         public LoginModel(){}
          public LoginModel(int id, string email, string password)
          {
              Id = id; 
              Email = email;
              Password = password;
          }
    }
}