using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHnue.Shared.Models
{
    public class AssignRole
    {
        public int Id { get; set; }
        public int AssigneeId { get; set; } = -1;
        public int AssigneePosId { get; set; } = -1;
        public int AssigneeDeptId { get; set; } = -1;
        public int AssignForDepartId { get; set; } = -1;
        public int StatusBeforeAssign { get; set; }
        public int StatusAfterAssign { get; set; }
        public bool IsPrivated { get; set; } = false;
        public int MinDays { get; set; } = -1;
        public int MaxDays { get; set; } = -1;
    }
    public class AssignRole_View: AssignRole
    {
        public string AssigneeName { get; set; }
        public string AssigneePosName { get; set; }
        public string AssigneeDeptName { get; set; }
        public string AssignForDepartName { get; set; }        
    }
}
