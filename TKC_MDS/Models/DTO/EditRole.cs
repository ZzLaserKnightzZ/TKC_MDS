namespace TKC_MDS.Models.DTO
{
	public class EditRole
	{
		public string RoleName { get; set; }
		public string RoleId { get; set; }

		public List<ClaimRole> Assign { get; set; }
	}
}
