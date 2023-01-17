using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm1
{
    class Fruit
    {
        public int x;
        public int y;
        public bool poison = false;
        public int time = 0;
        public FruitState state = FruitState.Empty;
        public bool existence = false;

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
                existence = false;
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
