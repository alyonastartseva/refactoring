using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm1.Classes
{
    static class Map
    {
        static public int Width = 1000;
        static public int Height = 1000;
        static public int CellSize = 10;

        static public int elementalAmountAllKindPlants = 10000;

        static public Random Random = new Random();

        static public List<Cell> Area;
        static public List<SimulationObject> SimulationObjects;
    }
}
