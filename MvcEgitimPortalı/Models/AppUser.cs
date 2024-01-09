using Microsoft.AspNetCore.Identity;

namespace MvcEgitimPortalı.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        
    }


}
