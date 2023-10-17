using System.ComponentModel.DataAnnotations;

namespace TKC_MDS.Models.DTO
{
	public class EditUser
	{
		public string UserId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		//[Compare(nameof(Password))]
		//public string ConfirmPassword { get; set; }
		public string Email { get; set; }

		public string Address { get; set; }
		public string NewRole { get; set; }
		public string OldRole { get; set; }
	}
}
