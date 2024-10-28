using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHnue.Shared
{
    public class UserRole
    {
        public int Id { get; set; }
        public int StaffId { get; set; }        
        public string? StaffName { get; set; }
        public string? RoleName { get; set; }
    }
    public class UserRoleView : UserRole
    {        
        public string? DeptId { get; set; }
     
    }
}
