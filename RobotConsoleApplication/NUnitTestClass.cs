using NUnit.Framework;
using SDKClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotConsoleApplication
{
    [TestFixture]
    class NUnitTestClass
    {
        [Test]
        public void MoveCommandTest()
        {
            var rf = new RobotFactory(new Robot());
            rf.SetArgument = 100;
            ACommand command = new MoveCommand(rf);
            string result = command.Execute();
            
            Assert.AreEqual(result, "MOVE 100 >> True");
        }

        [Test]
        public void MoveCommandTestInvalid()
        {
            var rf = new RobotFactory(new Robot());
            rf.SetArgument = -100;
            ACommand command = new MoveCommand(rf);
            string result = command.Execute();

            Assert.AreEqual(result, "MOVE -100 >> False");
        }

        [Test]
        public void TurnCommandTest()
        {
            var rf = new RobotFactory(new Robot());
            rf.SetArgument = 45;
            ACommand command = new TurnCommand(rf);
            string result = command.Execute();
            Assert.AreEqual(result, "TURN 45 >> True");
        }

        [Test]
        public void TurnCommandTestInvalid()
        {
            var rf = new RobotFactory(new Robot());
            rf.SetArgument = 450;
            ACommand command = new TurnCommand(rf);
            string result = command.Execute();
            Assert.AreEqual(result, "TURN 450 >> False");
        }

        [Test]
        public void BeepCommandTest()
        {
            var rf = new RobotFactory(new Robot());
            ACommand command = new BeepCommand(rf);
            string result = command.Execute();
            Assert.AreEqual(result, "BEEP >> True");
        }
    }
}
