using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm1
{
    class InfertilePoisonousPlant: Plant
    {
        static InfertilePoisonousPlant()
        {
            poison = true;
            edible = true;
            fruit = false;
        }
    }
}
