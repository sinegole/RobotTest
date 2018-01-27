using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClassLibrary
{
    public interface IRobot
    {
        bool Move(double distance);
        bool Turn(double angle);
        bool Beep();
    }
}
