using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace eHnue.Shared.Models
{
    public class GoAbroad
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int PurposeId { get; set; }
        public int ToCountryId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int ExpenseId { get; set; }
        public string? Commitment { get; set; }
       
        [Display(Name = "Số điện thoại ở nước ngoài")]
        public int IsPartyMember { get; set; }
        public string? OutboundPhone { get; set; }
        public string? Description { get; set; }
    }
}
