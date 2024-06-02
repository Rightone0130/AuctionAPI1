using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
