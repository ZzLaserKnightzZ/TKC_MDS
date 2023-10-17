namespace TKC_MDS.Models.DTO
{
	public class AddRole
	{
		public string RoleName { get; set; }
		public List<NewRoles> Assign { get; set; }
	}

	public class NewRoles
	{
		public Guid AccessRolesId { get; set; }
		public bool IsAllow { get; set; }
		public string? RoleName { get; set; }
		public string Name { get; set; }
	}
}
