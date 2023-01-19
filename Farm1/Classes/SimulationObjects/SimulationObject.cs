using System;
using System.Drawing;

namespace Farm1.Classes
{
    abstract class SimulationObject
    {
        protected static Random Random = new Random();

        public Point Coordinates;
        public Color Color;
        public bool IsAlive;

        public SimulationObject()
        {
            Coordinates = GetRandomPoint();
            IsAlive = true;
        }

        protected Point GetRandomPoint()
        {
            return new Point(Random.Next(1000), Random.Next(1000));
        }
    }
}
