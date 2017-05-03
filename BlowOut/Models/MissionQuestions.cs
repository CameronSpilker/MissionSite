using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{   [Table("MissionQuestions")]
    public class MissionQuestions
    {
        [Key]
        public int mission_question_id { get; set; }
        
        public int? mission_id { get; set; }
        
        public int? user_id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        
    }
}