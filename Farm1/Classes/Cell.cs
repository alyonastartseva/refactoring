using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Farm1
{
    class Cell
    {
        public readonly Point Coordinates;

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

        public Cell(int x, int y)
        {
            Coordinates = new Point(x, y);
        }        
    }
}
