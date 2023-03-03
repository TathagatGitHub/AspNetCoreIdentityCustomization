using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AspNetCoreIdentityCustomization.Core
{
    //public class PostLog
    //{
    //    //[Key]
    //    public int PostLogId { get; set; }


    //   // [Required]
    //   // [ForeignKey("Schedule")]
    //    public int SchedId { get; set; }

    // //   public virtual Schedule Schedule { get; set; }

    //   // [NotMapped]
    //    public string ScheduleName { get; set; }

    //   // [Required]
    //    public int WeekNbr { get; set; }

    //   // [Required]
    //   // [DisplayName("Week Date")]
    //   // [DataType(DataType.Date)]
    //   // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    //    public DateTime WeekDate { get; set; }

    //   // [Required]
    //  //  [DisplayName("Create Date")]
    //   // [DataType(DataType.Date)]
    //   // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    //    public DateTime CreateDt { get; set; }

    //    //[Required]
    //  //  [DisplayName("Update Date")]
    //   // [DataType(DataType.Date)]
    //    //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    //    public DateTime UpdateDt { get; set; }

    //    //[Required]
    //    //public string UpdatedBy { get; set; }
    //}
    public class PostLog

    {
        public int PostLogId { get; set; }
        public int SchedId { get; set; }
        public string ScheduleName { get; set; }
        public int WeekNbr { get; set; }
        public DateTime WeekDate { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime UpdateDt { get; set; }
    }

}
