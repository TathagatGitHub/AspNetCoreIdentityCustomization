using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreIdentityCustomization.Core
{

    public class SearchResponse
    {
        
        public string Status { get; set; }
        public ErrorResult ErrorResult { get; set; }
        public int TotalRecords { get; set; }
        public IList<PostLogLine> Data { get; set; }
    }
    public class PostLogLine
    {
        public string NetworkName { get; set; }
        public string DayPartDesc { get; set; }
        public int SpotLen { get; set; }
        public double Rate { get; set; }
        public double Imp { get; set; }
        public string SpotDate { get; set; }
        public string SpotTime { get; set; }
        public string MediaTypeCode { get; set; }
        public string ISCI { get; set; }
        public string SigmaProgramName { get; set; }
        public string BuyType { get; set; }
    }
    public class ErrorResult
    {
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }

}
