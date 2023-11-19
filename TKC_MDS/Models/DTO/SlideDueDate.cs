using Microsoft.VisualBasic;

namespace TKC_MDS.Models.DTO
{
	public class SlideDueDate
	{
		public List<ShiftDate> ShiftDate { get; set; } = new();
		public string CustID { get; set; } 
		public string DataType { get; set; }
		public string? PONo { get; set; } 
		public string? PlantCode { get; set; } 
		public string? OrdersNo { get; set; }
		public List<string>? PartsNo { get; set; } = new List<string>();
	}
	public class ShiftDate
	{
		public string FromDate { get; set; }
		public string FromPeriod { get; set; }
		public string FromTime { get; set; }
		public string ToDate { get; set; }
		public string ToPeriod { get; set; }
		public string ToTime { get; set; }

	}
}
