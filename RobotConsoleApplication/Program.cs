using RobotConsoleApplication.Model;
using SDKClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotConsoleApplication
{
    class Program
    {
        const int robotCount = 5; //Robot count
        ACommand command = null;
        List<RobotFactory> robots = null; //List of Robots (we will have 5 robots for test)
        List<ActionModel> actions = null; //List of Actions (every command will be stored in this list)

        static void Main(string[] args)
        {
            //We create new Init() method to skip static limitation
            var instance = new Program();
            instance.Init();
        }

        private void Init()
        {
            Console.WriteLine("======TEST ROBOT GORAN PANIC==========");

            //We will have several robots for test
            //Each Robot will have your RobotFactory and your sdk object.
            //In this case all robots using same SDK immplementation (class Robot()), 
            //but we can use diferent IRobot immplementaion for diferent kind of robots, 
            //for this reason each RobotFactory will have your sdk object and this depending of robot type.
            robots = new List<RobotFactory>();
            for (int i = 0; i < robotCount; i++)
            {
                robots.Add(new RobotFactory(new Robot()));
            }

            //Create store list
            actions = new List<ActionModel>();

            while (true)
            {
                //Simple console menu in loop
                Console.WriteLine("======================================");
                Console.WriteLine("1. SEND NEW COMMAND");
                Console.WriteLine("2. LIST ALL ACTIONS");
                Console.WriteLine("3. RE APPLY COMMAND");
                Console.WriteLine("0. EXIT");
                Console.WriteLine("======================================");
                string selectIdText = Console.ReadLine();
                int selectId;
                bool isNumeric = int.TryParse(selectIdText, out selectId);
                if (isNumeric)
                {
                    switch (selectId)
                    {
                        case 0:
                            {
                                Environment.Exit(0);
                            }
                            break;
                        case 1:
                            {
                                SendCommnd();
                            }
                            break;
                        case 2:
                            {
                                ListAll();
                            }
                            break;
                        case 3:
                            {
                                ReApply();
                            }
                            break;
                    }
                }
            }
        }

        #region Case Methods
        /// <summary>
        /// Create new action (send command to robot)
        /// </summary>
        private void SendCommnd()
        {
            Console.WriteLine("==========SEND NEW COMMAND===============");
            //Get robot ID
            Console.WriteLine("Enter robot Id (number between 0 and {0})", robotCount - 1);
            string robotIdText = Console.ReadLine();
            int robotId;
            bool isNumeric = int.TryParse(robotIdText, out robotId);
            if (!isNumeric || robotId < 0 || robotId > robotCount - 1)
            {
                Console.WriteLine("Wrong input try again");
                return;
            }

            //Get Comand Id
            Console.WriteLine("Enter command number (0 - MOVE; 1 - TURN; 2- BEEP)");
            string commandIdText = Console.ReadLine();
            int commandId;
            isNumeric = int.TryParse(commandIdText, out commandId);
            if (!isNumeric || commandId < 0 || commandId > 2)
            {
                Console.WriteLine("Wrong input try again");
                return;
            }

            //Get argumnt
            double argument = 0;
            switch (commandId)
            {
                case 0:
                    {
                        Console.WriteLine("Enter distance:");
                        string argumentText = Console.ReadLine();
                        isNumeric = double.TryParse(argumentText, out argument);
                        if (isNumeric)
                        {
                            robots[robotId].SetArgument = argument;
                            command = new MoveCommand(robots[robotId]);
                        }
                    }
                    break;
                case 1:
                    {
                        Console.WriteLine("Enter angle:");
                        string argumentText = Console.ReadLine();
                        isNumeric = double.TryParse(argumentText, out argument);
                        if (isNumeric)
                        {
                            robots[robotId].SetArgument = argument;
                            command = new TurnCommand(robots[robotId]);
                        }
                    }
                    break;
                case 2:
                    {
                        command = new BeepCommand(robots[robotId]);
                    }
                    break;
                default:
                    command = null;
                    break;

            }

            //Execute
            Console.WriteLine("Result:");
            Console.WriteLine(command.Execute());

            //Save command in list
            actions.Add(new ActionModel() { RobotId = robotId, CommandId = commandId, Parameter = argument });
        }

        /// <summary>
        /// Write all items in list
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine("==========LIST ALL====================");
            int i = 0;
            foreach(var item in actions)
            {
                Console.WriteLine("Action number {0}; RobotId: {1} CommandId {2} Parameter {3}", i++, item.RobotId, item.CommandId, item.Parameter);
            }
        }

        /// <summary>
        /// Use existing item from list to re-apply action on another robot
        /// </summary>
        private void ReApply()
        {
            Console.WriteLine("==========RE APPLY COMMAND==============");
            //Get action number
            Console.WriteLine("Enter action number");
            string actionIdText = Console.ReadLine();
            int actionId;
            bool isNumeric = int.TryParse(actionIdText, out actionId);
            if (!isNumeric || actionId < 0 || actionId > actions.Count)
            {
                Console.WriteLine("Acction number don't existing in list");
                return;
            }

            //Get new robot id
            Console.WriteLine("Enter robot Id (number between 0 and {0})", robotCount - 1);
            string robotIdText = Console.ReadLine();
            int robotId;
            isNumeric = int.TryParse(robotIdText, out robotId);
            if (!isNumeric || robotId < 0 || robotId > robotCount - 1)
            {
                Console.WriteLine("Wrong input try again");
                return;
            }

            //Execute action
            var item = actions[actionId];
            switch (item.CommandId)
            {
                case 0:
                    {
                       robots[robotId].SetArgument = item.Parameter;
                       command = new MoveCommand(robots[robotId]);
                    }
                    break;
                case 1:
                    {
                        robots[robotId].SetArgument = item.Parameter;
                        command = new TurnCommand(robots[robotId]);
                    }
                    break;
                case 2:
                    {
                        command = new BeepCommand(robots[robotId]);
                    }
                    break;
            }

            //Save action to list
            actions.Add(new ActionModel() { RobotId = robotId, CommandId = item.CommandId, Parameter = item.Parameter });
        }
        #endregion
    }
}
