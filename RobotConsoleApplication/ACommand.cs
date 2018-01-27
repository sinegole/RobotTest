using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotConsoleApplication
{
    abstract class ACommand
    {
        protected IReceiver receiver;

        public ACommand(IReceiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract string Execute();
    }
}
