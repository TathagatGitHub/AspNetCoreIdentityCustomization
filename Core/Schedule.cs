using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreIdentityCustomization.Core
{
    public class Schedule
    {
        [Key]
        public int SchedId { get; set; }

        [Required]
        public string ScheduleName { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string NetworkName { get; set; }

        [Required]
        public DateTime WeekDate { get; set; }


    }
}
