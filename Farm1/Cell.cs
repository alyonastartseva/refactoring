using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm1
{
    class Cell
    {
        public int x;
        public int y;
        public int fullness = 0;
        /* fullness:
        0 - empty \ seed
        1 - edible plant
        2 - edible fruiting plant
        3 - poisonous plant
        4 - poisonous fruiting plant
        5 - fruit
        6 - poisonous fruit
        7 - inedible plant
        8 - inedible fruiting plant
        9 - animal
        */
        public bool plantFruitingPoisonous = false;
        public bool plantFruitingEdible = false;
        public bool plantFruitingInEdible = false;
        public bool plantInfertilePoisonous = false;
        public bool plantInfertileEdible = false;
        public bool plantInfertileInEdible = false;
        public bool fruit = false;
        public bool plantSeed = false;
        public bool animal = false;

        public Cell(int X, int Y)
        {
            x = X;
            y = Y;
        }
        /*public int Definition()
        {
            if (plantInfertileEdible)
                fullness = 1;
            else if (plantFruitingEdible)
                fullness = 2;
            else if (plantInfertilePoisonous)
                fullness = 3;
            else if (plantFruitingPoisonous)
                fullness = 4;
            else if (fruit)
                fullness = 5;
            else if (fruitPoisonous)
                fullness = 6;
            else if (plantInfertileInEdible)
                fullness = 7;
            else if (plantFruitingInEdible)
                fullness = 8;
            return fullness;
        }*/
        
    }
}
