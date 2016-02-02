using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWest
{
    class Duelist
    {
        //instance variables
        private int health;
        private int bullets;
        private string name;

        //properties
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public int Bullets
        {
            get
            {
                return bullets;
            }
            set
            {
                bullets = value;
                if (bullets > 6)
                {
                    bullets = 6;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //Duelist constructor
        public Duelist(string theName)
        {
            Bullets = 6;
            Health = 5;
            Name = theName;
        }

        public bool Shoot(int range)
        {
            //calculates likeliness of a hit at a given range
            //returns true if bullet hits
            bool hit = false;
            int myRoll;
            Random roller = new Random();

            if (Bullets <= 0)
            {
                Console.WriteLine("{0} is out of bullets!", Name);
            }
            else
            {
                myRoll = roller.Next(10);
                if (myRoll > range)
                {
                    hit = true;
                }

                Bullets--;
            }

            return hit;

        }

        public void Reload()
        {
            Bullets += 2;
        }



    }
}
