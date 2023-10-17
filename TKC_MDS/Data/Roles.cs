using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;

namespace TKC_MDS.Data
{
    public class Roles : IdentityRole
    {
        public string? Description { get; set; }
    }
}
