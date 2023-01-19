using Farm1.Classes;
using System.Drawing;

namespace Farm1
{
    abstract class Plant: SimulationObject
    {
        public int time = 0; 
        
        public static bool poison;
        public static bool fruit;
        public static bool edible;

        public CellState state = CellState.Seed;

        public Plant() : base() {
            Color = Color.DeepPink;
            state = CellState.Seed;
        }
        
        public void Die()
        {
            IsAlive = false;
        }

        public Point Step()
        {
            time++;
            if (time <= 3)
            {
                state = CellState.Seed;
                Color = Color.Yellow;
            }
            else if (time <= 7)
            {
                state = CellState.Sprout;
                Color = Color.GreenYellow;
            }
            else if (time <= 14)
            {
                state = CellState.Green;
                Color = Color.Lime;
            }
            else if (time <= 15)
            {
                state = CellState.Function;
                Color = Color.Green;
            }
            else if (time <= 30)
            {
                state = CellState.Rotten;
                Color = Color.Chocolate;
            }
            else
            {
                IsAlive = false;
                time = 0;
                state = CellState.Empty;
                Color = Color.White;
            }
            return Coordinates;
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
