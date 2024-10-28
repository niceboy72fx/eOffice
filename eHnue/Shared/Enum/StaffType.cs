using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHnue.Shared.Enum
{
    public enum StaffType
    {
        [Display(Name = "Giảng viên")]
        GV,
        [Display(Name = "Chuyên viên")]
        CV,
        [Display(Name = "Khác")]
        Khac
    }
}
