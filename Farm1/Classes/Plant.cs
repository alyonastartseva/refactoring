using Farm1.Classes;

namespace Farm1
{
    class Plant: SimulationObject
    {
        public int time = 0; 
        
        public static bool poison;
        public static bool fruit;
        public static bool edible;

        public CellState state = CellState.Seed;

        public Plant() : base() { }
        
        public void Die()
        {
            IsAlive = false;
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
                IsAlive = false;
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
