using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eHnue.Shared.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên nước")]
        public string CountryName { get; set; }
        [Required]
        [Display(Name = "Mã nước")]
        public string CountryCode { get; set; }
        public string? ISOCode { get; set; }
    }
}
