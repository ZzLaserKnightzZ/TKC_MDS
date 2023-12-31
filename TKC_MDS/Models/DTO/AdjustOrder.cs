﻿namespace TKC_MDS.Models.DTO
{
	public class AdjustOrder
	{
        public string CustID { get; set; }
        public string OrdersNo { get; set; }
        public string PONo { get; set; }
        public string PlantCode { get; set; }
        public DateTime DueDate { get; set; }
        public string Period { get; set; }
        public string DueTime { get; set; }
        public string PartNo { get; set; }
        public long Qty { get; set; }
        public short? SentQty { get; set; }
        public string? Flag01 { get; set; }
        public string? Flag02 { get; set; }
        public string? Flag03 { get; set; }
        public string? Flag04 { get; set; }
        public string? Flag05 { get; set; }
        public string DataType { get; set; }
        public bool? Status { get; set; }
        public string? ImportBy { get; set; }
        public DateTime? ImportDate { get; set; }
        public bool? FirmOrder { get; set; }
        public bool? Exported { get; set; }
        public string? InvcNo { get; set; }
        public string DataFileName { get; set; }
        public string? Flag06 { get; set; }
        public string? Flag07 { get; set; }
        public string? Flag08 { get; set; }
        public string? Flag09 { get; set; }
        public string? Flag10 { get; set; }
        public string? PlantCode_Original { get; set; }
        public DateTime? DueDate_Original { get; set; }
        public string? Period_Original { get; set; }
        public string? DueTime_Original { get; set; }
        public long? Qty_Original { get; set; }
        public string PackageCD { get; set; }
    }
}
