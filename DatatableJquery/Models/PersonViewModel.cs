using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DatatableJquery.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
   
        public string lastname { get; set; }
        [Required(ErrorMessage = "This Field is Required")] public  string  birthday { get; set; }
        public string email { get; set; }
        [Required(ErrorMessage = "This Field is Required")] public decimal phone { get; set; }
        public string company { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public decimal zipcode { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}