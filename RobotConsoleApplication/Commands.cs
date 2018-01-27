using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotConsoleApplication
{
    /// <summary>
    /// Contain implement of different commands
    /// </summary>

    class MoveCommand : ACommand
    {
        public MoveCommand(IReceiver receiver)
            : base(receiver)
        {

        }
        public override string Execute()
        {
            receiver.SetAction(EAction.MOVE);
            return receiver.Execute();
        }
    }

    class TurnCommand : ACommand
    {
        public TurnCommand(IReceiver reciever)
            : base(reciever)
        {

        }
        public override string Execute()
        {
            receiver.SetAction(EAction.TURN);
            return receiver.Execute();
        }
    }

    class BeepCommand : ACommand
    {
        public BeepCommand(IReceiver reciever)
            : base(reciever)
        {

        }
        public override string Execute()
        {
            receiver.SetAction(EAction.BEEP);
            return receiver.Execute();
        }
    }
    
}
