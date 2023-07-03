using System;

namespace RobotApp
{

    class Robot
    {
        public enum Directions { NORTH, EAST, SOUTH, WEST }

        // these will be the properties of the robot
        private int? positionX;
        private int? positionY;
        private Directions? direction;

        // these will be the actions of the robot
        public void Place(int positionX, int positionY, Directions? direction = null)
        {
            // you can't place off the edge :)
            if (positionX > 4 || positionX < 0 || positionY > 4 || positionY < 0)
                throw new Exception();

            this.positionX = positionX;
            this.positionY = positionY;
            this.direction = direction ?? this.direction;
        }

        public void Move()
        {
            // when facing north, increment y axis by 1
            if (direction == Directions.NORTH && positionY + 1 <= 4)
                positionY++;

            // when facing south, decrement y axis by 1
            else if (direction == Directions.SOUTH && positionY - 1 >= 0)
                positionY--;

            // when facing east, increment x axis by 1
            else if (direction == Directions.EAST && positionX + 1 <= 4)
                positionX++;

            // when facing west, decrement x axis by 1
            else if (direction == Directions.WEST && positionX - 1 >= 0)
                positionX--;

            else
                Console.WriteLine("You will fall off the table! That action is prevented.");
        }

        public void Left()
        {
            // rotating counter clock-wise
            direction = direction != Directions.NORTH ? direction - 1 : Directions.WEST;
        }

        public void Right()
        {
            // rotating clock-wise
            direction = direction != Directions.WEST ? direction + 1 : Directions.NORTH;
        }

        public void Report()
        {
            Console.WriteLine($"X:{positionX}, Y:{positionY}, F:{direction}");
        }
    }
}
