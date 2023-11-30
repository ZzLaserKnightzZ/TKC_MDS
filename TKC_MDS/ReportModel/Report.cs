namespace TKC_MDS.ReportModel
{
    public class Report
    {
        //1mouth per object
        public string IssueDateTime { get; set; }
        public string Custumer { get; set; }
        public string DataType { get; set; }

        public string Factory { get; set; }
        public List<Part> Part { get; set;}
    }

    public class Part
    {
        public string Line { get; set; }
        public string KbNo { get; set; }
        public string CustPart { get; set; }
        public string TKC_Part { get; set;}
        public string PartName { get; set; }
        public List<PartPerDay> PartPerDay { get; set; }
    }

    public class PartPerDay
    {
        public int Day { get; set; }
        public decimal Count { get; set; }
    }
}
