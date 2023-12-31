﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TKC_MDS.Models
{
	public  class T_SchOrdersPart
	{
		public string CustID { get; set; }
		public string OrdersNo { get; set; }
		public string PONo { get; set; } = string.Empty;
		public string PlantCode { get; set; } = string.Empty;
		public string DueDate { get; set; }
		public string Period { get; set; } = string.Empty;
		public string DueTime { get; set; } = string.Empty;
		public string PartNo { get; set; } 
		public long Qty { get; set; }
		public short SentQty { get; set; }
		public string Flag01 { get; set; } = string.Empty;
		public string Flag02 { get; set; } = string.Empty;
		public string Flag03 { get; set; } = string.Empty;
		public string Flag04 { get; set; } = string.Empty;
		public string Flag05 { get; set; } = string.Empty;
		public string DataType { get; set; }
		public bool? Status { get; set; }
		public string ImportBy { get; set; }
		public string ImportDate { get; set; } = string.Empty;
		public bool? FirmOrder { get; set; }
		public bool? Exported { get; set; }
		public string InvcNo { get; set; }
		public string DataFileName { get; set; }
		public string Flag06 { get; set; } = string.Empty;
		public string Flag07 { get; set; } = string.Empty;
		public string Flag08 { get; set; } = string.Empty;
		public string Flag09 { get; set; } = string.Empty;
		public string Flag10 { get; set; } = string.Empty;
		public string PackageCD { get; set; }
	}
}