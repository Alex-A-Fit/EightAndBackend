using System.ComponentModel.DataAnnotations;
namespace EightAnd_Backend.Dtos
{
    public class GroupDto
    {
        public string CompanyName { get; set; }
        public string Location { get; set; }
        // public string WebUrl { get; set; } ="";
        // public string Photo { get; set; } = "";
        // public string Logo { get; set; } = "";
        public string Description { get; set; }
        public string Director { get; set; }
        public bool Roster { get; set; }
        
    }
}