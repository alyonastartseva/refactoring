using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm1
{
    class InfertileInEdiblePlant : Plant
    {
        static InfertileInEdiblePlant()
        {
            poison = false;
            edible = false;
            fruit = false;
        }
    }
}
