Solution have 2 projects:
1. RobotConsoleApplication - simple console application
2. SDKClassLibrary - test SDK files

I was using Console because the point of this task is how I can implement a specific problem, the user interface will only complicated code.

This task can be immplemented on many kind.
I guess we can have a lot of robots, and robots can be different models. This means that we will have several immplementation for IRobot class in SDK.
Also I was assume that each robot can have many commands (and some can be comblex - combination of several base commands).
For this reason I was immplemented command patern to easy can manage commands and create complex comands.

RobotFactory represent phisical robot and contain parameter IRobot (reprezent IRobot implementation for specific robot model).
We can add new commands in Commands class.
IReceiver and ACommand are command patern classes.

For test I was used NUnit (NUnitTestClass.cs) to test all immplemented commands.