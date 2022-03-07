using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommanLayer.Model
{
    public  class Students
    {
        
        public int ID { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string mobile { get; set; }
        [Required]
        public String Gender { get; set; }
        [Required]
        public String Address { get; set; }


      
    }
}
