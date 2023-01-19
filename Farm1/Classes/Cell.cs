using Farm1.Classes;
using System.Collections.Generic;
using System.Drawing;

namespace Farm1
{
    class Cell
    {
        public readonly Point Coordinates;

        public List<SimulationObject> Objects;

        public Cell(int x, int y)
        {
            Coordinates = new Point(x, y);
            Objects = new List<SimulationObject>();
        }        
    }
}
