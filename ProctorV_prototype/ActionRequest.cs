using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProctorV_prototype.Messages
{
    public class ActionRequest
    {
        public ActionType Action {  get; set; }
        public Dictionary<string, object> Parameters { get; }
    }
}
