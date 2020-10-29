using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}