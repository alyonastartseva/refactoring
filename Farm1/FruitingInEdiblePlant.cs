using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm1
{
    class FruitingInEdiblePlant: Plant 
    {
        public FruitingInEdiblePlant(int X, int Y)
        {
            x = X;
            y = Y;
        }

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

        public void Mechanochoria(Dictionary<int, Cell> cells, Dictionary<int, FruitingInEdiblePlant> plantFruitingInEdible, int amountX, int amountY)
        {
            int xx = x;
            int yy = y;
            int check = 0;
            if (xx < amountX)
            {
                check = (xx + 1) + yy * amountX;
                if (cells[check].fullness == 0)
                {
                    cells[check].fullness = 4;
                    cells[check].plantSeed = true;
                    plantFruitingInEdible[check].existence = true;
                }
            }
            if (xx > 1)
            {
                check = (xx - 1) + yy * amountX;
                if (cells[check].fullness == 0)
                {
                    cells[check].fullness = 4;
                    cells[check].plantSeed = true;
                    plantFruitingInEdible[check].existence = true;
                }
            }
            if (yy < amountY - 1)
            {
                check = xx + (yy + 1) * amountX;
                if (cells[check].fullness == 0)
                {
                    cells[check].fullness = 4;
                    cells[check].plantSeed = true;
                    plantFruitingInEdible[check].existence = true;
                }
            }
            if (yy > 0)
            {
                check = xx + (yy - 1) * amountX;
                if (cells[check].fullness == 0)
                {
                    cells[check].fullness = 4;
                    cells[check].plantSeed = true;
                    plantFruitingInEdible[check].existence = true;
                }
            }
        }
    }
}
