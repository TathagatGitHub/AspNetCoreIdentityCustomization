using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreIdentityCustomization.Core
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public String UserName { get; set; }

       
    }
}
