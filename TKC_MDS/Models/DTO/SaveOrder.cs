using System.ComponentModel.DataAnnotations;

namespace TKC_MDS.Models.DTO
{
	public class SaveOrder
	{
		[Required]
		public string CusTumerId { get; set; }
		[Required]
		public string DataType { get; set; }
		public IFormFile Excell { get; set; }
	}
}
