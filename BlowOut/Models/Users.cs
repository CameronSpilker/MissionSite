using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{   [Table("Users")]
    public class Users
    {
        [Key]
        public int user_id { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",ErrorMessage="Please provide a valid email")]
        [DisplayName("Email")]
        public string user_email { get; set; }

        [Required(ErrorMessage="Please provide a password", AllowEmptyStrings=false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [DisplayName("Password")]
        public string password { get; set; }
        
        [Required(ErrorMessage="Please provide a first name", AllowEmptyStrings=false)]
        [DisplayName("Frist Name")]
        public string first_name { get; set; }
        
        [Required(ErrorMessage="Please provide a last name", AllowEmptyStrings=false)]
        [DisplayName("Last Name")]
        public string last_name { get; set; }
    

    }
}