using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorV_prototype.Messages
{
    internal class ActionResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, object> info { get; set; }
        public ActionResult() 
        {
            Success = false;
            info = new Dictionary<string, object>();
        }
    }
}
