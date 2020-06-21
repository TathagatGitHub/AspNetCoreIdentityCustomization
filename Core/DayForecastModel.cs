using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreIdentityCustomization.Core
{
    public class DayForecastModel
    {
        public string weather_state_name { get; set; }
        public string applicable_date { get; set; }
        public float min_temp { get; set; }
        public float max_temp { get; set; }
    }
}
