using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHnue.Shared
{
    public class ResponseData
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public int StaffId { get; set; }
    }
    public  class ResponseObj
    {
        public bool success { get; set; }
        public ResponseData data { get; set; }
        public int total { get; set; }
        public string message { get; set; }
    }
}
