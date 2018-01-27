using SDKClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotConsoleApplication
{
    /// <summary>
    /// Command patern implemention, RobotFactory represent Robot
    /// </summary>
    class RobotFactory : IReceiver
    {
        double argument;
        EAction currentAction;
        IRobot sdkLibrary; //Each robot contain one sdk implementation and this dependenc of robot type.

        public RobotFactory(IRobot sdk)
        {
            sdkLibrary = sdk;
        }

        public double SetArgument
        {
            set
            {
                argument = value;
            }
        }

        public void SetAction(EAction action)
        {
            currentAction = action;
        }

        public string Execute()
        {
            string result;
            switch(currentAction)
            {
                case EAction.MOVE:
                    {
                        bool response = sdkLibrary.Move(argument);
                        result = String.Format("MOVE {0} >> {1}", argument, response);
                    }
                break;
                case EAction.TURN:
                    {
                        bool response = sdkLibrary.Turn(argument);
                        result = String.Format("TURN {0} >> {1}", argument, response);
                    }
                    break;
                case EAction.BEEP:
                    {
                        bool response = sdkLibrary.Beep();
                        result = String.Format("BEEP >> {0}", response);
                    }
                    break;
                default:
                    result = String.Format("WRONG COMMAND");
                    break;

            }
            return result;
        }
    }
}
