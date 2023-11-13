using Microsoft.VisualBasic;

namespace TKC_MDS.Models.DTO
{
	public class SlideDueDate
	{
		public string CustID { get; set; } = string.Empty;
		public bool DataType { get; set; }
		public string PONo { get; set; } = string.Empty;
		public string PlantCode { get; set; } = string.Empty;
		public string OrdersNo { get; set; } = string.Empty;
		public List<DueDate>? Shift { get; set; } 
		

	}
	public class Duedate
	{
		public string FromDate { get; set; }
		public string FromPeriod { get; set; }
		public string FromTime { get; set; }
		public string ToDate { get; set;}
		public string ToPeriod { get; set; }
		public string ToTime { get; set; }

	}
}
