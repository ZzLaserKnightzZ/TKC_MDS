using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TKC_MDS.Models;

namespace TKC_MDS.Data
{
    public class MSD_Context : IdentityDbContext<AppUser, Roles, string>
    {
        public MSD_Context(DbContextOptions<MSD_Context> options)
            : base(options)
        {

        }
		#region role
		/*
		public DbSet<SaveOrderRoles> SaveOrderRoles { get; set; }
		public DbSet<AdjustOrderRoles> AdjustOrderRoles { get; set; }
		public DbSet<DataTypeRoles> DataTypeRoles { get; set; }
		public DbSet<ReportRoles> ReportRoles { get; set; }
        */
		public DbSet<MDS_Roles> MDS_Roles { get; set; }
		public DbSet<ManageUserRoles> ManageUserRoles { get; set; }
        
		public DbSet<ClaimRole> ClaimRoles { get; set; }
		#endregion

		protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            Builder.Seed();
        }
    }
}
