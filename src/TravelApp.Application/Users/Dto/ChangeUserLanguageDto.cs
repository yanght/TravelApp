using System.ComponentModel.DataAnnotations;

namespace TravelApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}