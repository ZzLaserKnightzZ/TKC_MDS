using System.ComponentModel.DataAnnotations;

namespace TKC_MDS.Models.DTO
{
	public class AddUser
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
		[Required]
		public string Email { get; set; }

		public string Address { get; set; }
		[Required]
		public string Role { get; set; }
		
	}
}
