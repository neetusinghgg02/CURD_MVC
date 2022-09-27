using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace curd_All.Models
{
    public class EmpModel
    {
        public int id { get; set; }
        [Required]
        public string ename { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string edept { get; set; }
    }
}