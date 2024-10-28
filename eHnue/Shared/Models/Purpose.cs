using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eHnue.Shared.Models
{
    public class Purpose
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Mục đích đi NN")]
        public string PurposeName { get; set; } = "";
        [Required]
        [Display(Name = "Loại mục đích")]
        //Loại: 1 Công tác/2 Nghỉ phép/3 Kết hợp công tác, nghỉ phép
        public bool IsPrivate { get; set; }

    }
}
