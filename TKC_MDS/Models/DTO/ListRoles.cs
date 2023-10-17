namespace TKC_MDS.Models.DTO
{
	public class ListRoles
	{
		public string RoleName { get; set; }
		public string RoleId { get; set; }
		public List<ClaimRole> claimRole { get; set; }
	}
}
