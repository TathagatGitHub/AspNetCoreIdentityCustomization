using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreIdentityCustomization.Core
{
    class PostLogLine
    {
        public string NetworkName { get; set; }
        public string DayPartDesc { get; set; }
        public int SpotLen { get; set; }
        public double Rate { get; set; }
        public double Imp { get; set; }
        public DateTime SpotDate { get; set; }
        public DateTime SpotTime { get; set; }
        public string MediaTypeCode { get; set; }
        public string ISCI { get; set; }
        public string SigmaProgramName { get; set; }
        public string BuyType { get; set; }
    }
}
