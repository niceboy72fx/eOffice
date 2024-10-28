using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHnue.Shared
{
    public class StaffAPI_Data_Pos
    {
        public int PositionId { get; set; }
    }
    public class StaffAPI_Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int TitleId { get; set; }
        public int DegreeId { get; set; }
        public bool IsMoved { get; set; }
        public bool IsRetired { get; set; }
        public bool IsProbation { get; set; }
        public int DepartmentId { get; set; }
        public int TeachingInId { get; set; }
        public string Email { get; set; }
        public int[] PositionIds { get; set; }
    }
    public class StaffAPI_View
    {       
        public bool success { get; set; }
        public StaffAPI_Data data { get; set; }
        public int total { get; set; }
        public string message { get; set; }

    }
    public class StaffNameOnly
    {
        public int Id { get; set; }
        public string Name { get; set; }        
    }
}
