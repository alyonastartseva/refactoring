using Farm1.Classes;
using System.Drawing;

namespace Farm1
{
    class Fruit: SimulationObject
    {
        public bool poison = false;
        public int time = 0;
        public FruitState state = FruitState.Empty;

        public Fruit() : base() {
            Color = Color.White;
        }

        public void Update()
        {
            time++;
            if (time <= 5)
            {
                state = FruitState.Immature;
                Color = Color.Blue;
            }
            else if (time <= 10)
            {
                state = FruitState.Medium;
                Color = Color.BlueViolet;
            }
            else if (time <= 40)
            {
                state = FruitState.Done;
                if (poison)
                    Color = Color.Magenta;
                else
                    Color = Color.Red;
            }
            else if (time <= 70)
            {
                state = FruitState.Rotten;
                Color = Color.Chocolate;
            }
            else
            {
                IsAlive = false;
                time = 0;
                state = FruitState.Empty;
                Color = Color.White;
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
