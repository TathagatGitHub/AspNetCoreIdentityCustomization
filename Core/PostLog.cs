using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core
{
    class PostLog
    {
        [Key]
        public int PostLogId { get; set; }

 
        [Required]
        [ForeignKey("Schedule")]
        public int SchedId { get; set; }

        public virtual Schedule Schedule { get; set; }

        [NotMapped]
        public string ScheduleName { get; set; }

        [Required]
        public int WeekNbr { get; set; }

        [Required]
        public DateTime WeekDate { get; set; }

        [Required]
        public DateTime CreateDt { get; set; }

        [Required]
        public DateTime UpdateDt { get; set; }

        [Required]
        public User UpdatedBy { get; set; }
    }
}
