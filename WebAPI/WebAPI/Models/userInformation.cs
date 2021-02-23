using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class userInformation : IdentityUser
    {
        public string UserId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string creation_timestamp { get; set; }
        public string lastlogin_timestamp { get; set; }
        public string token { get; set; }
    }
}