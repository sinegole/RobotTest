using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotConsoleApplication.Model
{
    /// <summary>
    /// Model for storing actions
    /// </summary>
    public class ActionModel
    {
        public int RobotId {get;set;}

        public int CommandId { get; set; }

        public double Parameter { get; set; }
    }
}
