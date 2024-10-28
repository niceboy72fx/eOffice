using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eHnue.Shared.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên chi phí")]
        public string ExpenseName { get; set; }
    }
}
