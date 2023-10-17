using TKC_MDS.Data;

namespace TKC_MDS.Models.DTO
{
	public class ListUser
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public IList<string> Roles { get; set; } 
	}
}
