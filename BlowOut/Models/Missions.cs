using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{   [Table("Missions")]
    public class Missions
    {
        [Key]
        public int mission_id { get; set; }
        public string mission_name { get; set; }
        public string  president_name { get; set; }
        public string address { get; set; }
        public string language { get; set; }
        public string dominate_religion { get; set; }
        public string mission_flag { get; set; }
        public string climate { get; set; }
    }
}