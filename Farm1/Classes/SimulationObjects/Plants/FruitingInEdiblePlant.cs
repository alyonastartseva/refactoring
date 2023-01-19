using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm1
{
    class FruitingInEdiblePlant: Plant 
    {
        static FruitingInEdiblePlant()
        {
            poison = false;
            edible = false;
            fruit = true;
        }

        public Fruit Fruiting(Fruit fruit)
        {
            fruit.poison = poison;
            return fruit;
        }
    }
}
