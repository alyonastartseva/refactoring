using Farm1.Classes;

namespace Farm1
{
    class Fruit: SimulationObject
    {
        public bool poison = false;
        public int time = 0;
        public FruitState state = FruitState.Empty;

        public Fruit() : base() { }

        public void Update()
        {
            time++;
            if (time <= 5)
                state = FruitState.Immature;
            else if (time <= 10)
                state = FruitState.Medium;
            else if (time <= 40)
                state = FruitState.Done;
            else if (time <= 70)
                state = FruitState.Rotten;
            else
            {
                IsAlive = false;
                time = 0;
                state = FruitState.Empty;
            }
        }

    }

    enum FruitState
    {
        Empty,
        Immature,
        Medium,
        Done,
        Rotten
    }
}
