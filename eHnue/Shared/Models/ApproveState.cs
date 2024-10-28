using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHnue.Shared.Models
{
    public class ApproveState
    {
        [Key]
        public int Id { get; set; }
        public int State { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
    }
}
