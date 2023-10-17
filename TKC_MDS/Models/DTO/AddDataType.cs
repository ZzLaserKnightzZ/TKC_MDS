namespace TKC_MDS.Models.DTO
{
	public class AddDataType
	{
		public string CustumerId { get; set; }
		public string TypeCode { get; set; }
		public bool IsPO { get; set; }
		public bool CreateByMSD { get; set; }
		public bool IsPrintPOS { get; set; }
		public bool IsShowInReport { get; set; }
		public bool IsCombind_99 { get; set; }
		public bool DeleteBeforeSameData { get; set; }
		public bool OneColHasManyRowsDue { get; set; }
		public bool Due { get; set; }
		public int DataOneSet { get; set; }
		public int DataRolCount { get; set; }
		public int StringOfOneSet { get; set; }
		public bool HaveSeperator { get; set; }
		public string Seperator { get; set; }
	}
}
