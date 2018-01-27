using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotConsoleApplication
{
    enum EAction
    {
        MOVE,
        TURN,
        BEEP
    }

    interface IReceiver
    {
        void SetAction(EAction action);
        string Execute();
    }
}
