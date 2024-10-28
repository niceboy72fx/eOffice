using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eHnue.Shared.Models
{
    public class Staff
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }
        [Required]

        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Giới tính")]
        public int Sex { get; set; }

        public int TitleID { get; set; }
        
        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Điện thoại")]
        public string? MobilePhone { get; set; }
        public int UserRight { get; set; }
        
    }
}
