
namespace TKC_MDS.Models
{
	public class ClaimRole
	{
		public int Id { get; set; }
		public Guid AccessRolesId { get; set; }
		public Guid RoleId { get; set; }
		public bool IsAllow { get; set; }
		public string? RoleName { get; set; }
		public string Name { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.UtcNow;

	}
}
