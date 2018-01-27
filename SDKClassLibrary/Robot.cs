using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClassLibrary
{
    public sealed class Robot : IRobot
    {
        public bool Move(double distance)
        {
            return distance > 0;
        }

        public bool Turn(double angle)
        {
            return angle < 360 && angle > -360;
        }

        public bool Beep()
        {
            return true;
        }
    }
}
