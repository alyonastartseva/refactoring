using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm1
{
    class Plant
    {
        public int time = 0; 
        public int x;
        public int y;
        public static bool poison;
        public static bool fruit;
        public static bool edible;
        public CellState state = CellState.Seed;
        public bool existence = false;

        
        
        public void Die()
        {
            existence = false;
        }

        public CellState Step()
        {
            time++;
            if (time <= 3)
                state = CellState.Seed;
            else if (time <= 7)
                state = CellState.Sprout;
            else if (time <= 14)
                state = CellState.Green;
            else if (time <= 15)
                state = CellState.Function;
            else if (time <= 30)
                state = CellState.Rotten;
            else
            {
                existence = false;
                time = 0;
                state = CellState.Empty;
            }
            return state;
        }

    }

    enum CellState
    {
        Empty,
        Seed,
        Sprout,
        Green,
        Function,
        Rotten

    }
}
