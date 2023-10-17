using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TKC_MDS.Data
{
    public class AppUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
