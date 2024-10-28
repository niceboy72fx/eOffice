using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eHnue.Shared.Enum
{
    public enum RegStatus
    {
        [Display(Name = "Khởi tạo")]
        Init = 0,
        [Display(Name = "Từ chối")]
        Reject = 1,
        [Display(Name = "Tạm dừng")]
        Postpone = 2,
        [Display(Name = "Đang xử lý")]
        Processing = 3,
        [Display(Name = "Đã duyệt")]
        Approved = 4,
        [Display(Name = "Hoàn thành")]
        Finished = 9
    }
}
