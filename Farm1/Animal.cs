using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm1
{
    class Animal
    {
        public int satiety = 100;
        public int health = 100;
        public int location = 0;
        public int x = 0;
        public int y = 0;
        Random rnd = new Random();
        public bool existence = true;

        public int Step(Dictionary <int, Cell> cells) //New logic with Dictionary Cells!
        {
            if (satiety > 0)
                satiety--;
            else
                health--;

            if (health == 0)
                Die();

            if (satiety > 40)
            {
                x += rnd.Next(-1, 1);
                y += rnd.Next(-1, 1);
            }
            else
            {
                x += rnd.Next(-1, 0);
                y += rnd.Next(-1, 0);
            }

            if (x < 0)
                x *= (-1);

            if (y < 0)
                y *= (-1);

            if (x > 1000)
                x = 1000 - x;

            if (y > 1000)
                y = 1000 - 1;


            location = x + y * 1000;

            if (location == 0)
                location++;

            return location;
        }

        public void Eat(int success)
        {
            satiety += success;
        }

        public void Die() //Edit
        {
            existence = false;
        }
    }
}
