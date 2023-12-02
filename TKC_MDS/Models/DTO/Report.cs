using Org.BouncyCastle.Bcpg.OpenPgp;

namespace TKC_MDS.Models.DTO
{
	public class Report
	{
		public string? CustId { get; set; }
		public string? DataType { get; set; }
		public string? ReportType { get; set; }
		public string? ReportMount { get; set; }
		public string? DocReportType { get; set; }
		public string? Plan { get; set; }
		public string? Period { get; set; }
		public string? DueTime { get; set; }
		public string? PNCust { get; set; }

	}
}
