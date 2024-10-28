using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using eHnue.Shared.Enum;
namespace eHnue.Shared.Models
{
    
    public class Registration
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public enum Title
        {
            CN,
            Ths,
            TS,
            [Display(Name = "PGS, TS")]
            PGS,
            [Display(Name = "GS, TS")]
            GS
        }
        public string Name { get; set; }
        public StaffType StaffType { get; set; }
        public int DepartmentID { get; set; }
        public int PurposeId { get; set; }
        [Required]
        public int ToCountryId { get; set; }
        public string? Cities { get; set; }
        [Required]
        public DateTime FromDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime ToDate { get; set; } = DateTime.Now;
        public int ExpenseId { get; set; }
        public string? Commitment { get; set; }
        public bool IsPartyMember { get; set; }
        public string? MobiPhone { get; set; }
        [Display(Name = "Số điện thoại ở nước ngoài")]
        public string? OutboundPhone { get; set; }
        [Display(Name = "Mô tả nội dung đi nước ngoài")]
        public string? Email { get; set; }
        public string? Description { get; set; }
        public int RegistrationType { get; set; } 
        public RegStatus Status { get; set; }
        public int ApprovedStatus { get; set; }
        public bool IsPrivate { get; set; }
        
    }

    public class Registration_View: Registration
    {
    /*public int Id { get; set; }
    public int StaffId { get; set; }
    
    public string Name { get; set; }
    public StaffType StaffType { get; set; }
    public int DepartmentID { get; set; }
    public int PurposeId { get; set; }
    [Required]
    public int ToCountryId { get; set; }
    public string Cities { get; set; }
    [Required]
    public DateTime FromDate { get; set; } = DateTime.Now;
    [Required]
    public DateTime ToDate { get; set; } = DateTime.Now;
    public int ExpenseId { get; set; }
    public string? Commitment { get; set; }
    public bool IsPartyMember { get; set; }
    public string? MobiPhone { get; set; }
    [Display(Name = "Số điện thoại ở nước ngoài")]
    public string? OutboundPhone { get; set; }
    [Display(Name = "Mô tả nội dung đi nước ngoài")]
    public string? Email { get; set; }
    public string? Description { get; set; }
    public int RegistrationType { get; set; }
    public RegStatus Status { get; set; }
    public int ApprovedStatus { get; set; }
    */
    public int StatusAfterApprove { get; set; }
    }

    public class ApproveLog
    {
        public int Id { get; set; }
        public int RegistrationID { get; set; }
        public string ApproveDate { get; set; }
        public int ApproveStaffId { get; set; }
        public int FromStatus { get; set; }
        public int ToStatus { get; set; }
        public string? Note { get; set; }
    }
}
