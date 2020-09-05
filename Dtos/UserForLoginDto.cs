using System.ComponentModel.DataAnnotations;

namespace AutoSAAS.Dtos
{
    public class UserForLoginDto
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}