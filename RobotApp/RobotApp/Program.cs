using System;
using static RobotApp.Robot;

namespace RobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = null;
            Console.WriteLine("WELCOME TO ROBOT SIMULATION APP! (Type QUIT to exit)");
            Console.WriteLine("Start by using the PLACE command.");

            while (true)
            {
                var line = Console.ReadLine();
                var command = line.Split(' ');

                if (command[0] != "PLACE" && command[0] != "QUIT" && robot == null)
                {
                    command[0] = "INVALID";
                }

                switch (command[0])
                {
                    case "PLACE":
                        try
                        {
                            //parameter validations:
                            var parameters = command[1].Split(',');
                            var positionX = int.Parse(parameters[0]);
                            var positionY = int.Parse(parameters[1]);
                            
                            if (parameters.Length == 3)
                            {
                                // direction REQUIRED when NOT placed
                                var direction = (Directions)Enum.Parse(typeof(Directions), parameters[2]);
                                robot = new Robot();
                                robot.Place(positionX, positionY, direction);
                            }
                            else if (parameters.Length == 2 && robot != null)
                            {
                                // direction OPTIONAL when already placed
                                robot.Place(positionX, positionY);
                            }
                            else
                            {
                                Console.WriteLine("Number of parameters is invalid!");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid parameters!");
                        }
                        break;
                    case "MOVE":
                        robot.Move();
                        break;
                    case "LEFT":
                        robot.Left();
                        break;
                    case "RIGHT":
                        robot.Right();
                        break;
                    case "REPORT":
                        robot.Report();
                        break;
                    case "QUIT":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }
    }
}

//---------------------
//|0,4|1,4|2,4|3,4|4,4|
//--------------------- 
//|0,3|1,3|2,3|3,3|4,3|
//--------------------- 
//|0,2|1,2|2,2|3,2|4,2|
//--------------------- 
//|0,1|1,1|2,1|3,1|4,1|
//--------------------- 
//|0,0|1,0|2,0|3,0|4,0|
//--------------------- 