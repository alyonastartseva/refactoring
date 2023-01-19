using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm1
{
    class FruitingPoisonousPlant: Plant
    {
        static FruitingPoisonousPlant()
        {
            poison = true;
            edible = true;
            fruit = true;
        }

        public Fruit Fruiting(Fruit fruit)
        {
            fruit.poison = poison;
            return fruit;
        }
    }
}
