using System.ComponentModel.DataAnnotations;

namespace TKC_MDS.Models
{
	public class SaveOrderRoles
	{
		
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public string? Description { get; set; }
		public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
	}

	public class AdjustOrderRoles
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public string? Description { get; set; }
		public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
	}

	public class DataTypeRoles
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public string? Description { get; set; }
		public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
	}

	public class ReportRoles
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public string? Description { get; set; }
		public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
	}

	public class ManageUserRoles
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public string? Description { get; set; }
		public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
	}

	public class UpdateRole
	{
		public Guid roleId { get; set; } = Guid.NewGuid();
		public string Name { get; set; }

		public List<ClaimRole> Assign { get; set; }
	}
}
