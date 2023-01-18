using Farm1.Classes;
using System;
using System.Collections.Generic;

namespace Farm1
{
    class Animal: SimulationObject
    {
        public int satiety = 100;
        public int health = 100;
        public int location = 0;

        Random rnd = new Random();

        public Animal() : base() { }

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
                Coordinates.X += rnd.Next(-1, 1);
                Coordinates.Y += rnd.Next(-1, 1);
            }
            else
            {
                Coordinates.X += rnd.Next(-1, 0);
                Coordinates.Y += rnd.Next(-1, 0);
            }

            if (Coordinates.X < 0)
                Coordinates.X *= (-1);

            if (Coordinates.Y < 0)
                Coordinates.Y *= (-1);

            if (Coordinates.X > 1000)
                Coordinates.X = 1000 - Coordinates.X;

            if (Coordinates.Y > 1000)
                Coordinates.Y = 1000 - 1;


            location = Coordinates.X + Coordinates.Y * 1000;

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
            IsAlive = false;
        }
    }
}
