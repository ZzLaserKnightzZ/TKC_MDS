using System.ComponentModel.DataAnnotations;

namespace TKC_MDS.Models.DTO
{
	public class AddDataType
	{

		[Required]
		public string CustID { get; set; }
		[Required]
		public string TypeCode { get; set; }
		public bool DeleteOld { get; set; }
		public bool FirmOrder { get; set; }
		public bool MakeMDS { get; set; }
		public bool ShowInSch { get; set; }
		public string? MixedSchWith { get; set; }
		public bool RowManyDue { get; set; }
		public bool ManyDueType { get; set; }
		public int ManyDueDataNo { get; set; }
		public int ManyDueSetNo { get; set; }
		public int ManyDueDataLong { get; set; }
		public bool ForPOS { get; set; }
		public bool SepMDSbyFlag01 { get; set; }
		[Required]
		public string? Note { get; set; }
		//table ...conv
		//public bool HaveSeperator { get; set; }
		public string Seperator { get; set; }

		public List<Field>? FieldsList { get; set; }
	}

	public class  Field
	{
		public string? Name { get; set; }
		public short? StartPosition { get; set; }
		public short? EndPosition { get; set;}
		public int? FieldId { get; set; }
	}
}
