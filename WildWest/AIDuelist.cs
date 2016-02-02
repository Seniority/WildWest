using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWest
{
    class AIDuelist: Duelist
    {
        private Duelist player;

        public AIDuelist (Duelist thePlayer, string theName): base(theName)
        {
            player = thePlayer;
        }

        public int ChoosePlay(int range) //50% chance that AI will handle positioning or weapon. 50% chance that AI will shoot.
        {
            int thePlay;
            Random roller = new Random();

            if (Bullets <= 0)
            {
                Console.WriteLine(">> " + Name + " is reloading!");
                Reload();
            }
            else
            {
                thePlay = roller.Next(6);
                switch (thePlay)
                {
                    case 0: //go closer
                        Console.WriteLine(">> {0} moves closer.", Name);
                        range--;
                        break;
                    case 1: //back up
                        Console.WriteLine(">> {0} backs away", Name);
                        range++;
                        break;
                    case 2: //reload if Bullets are not maxed out. otherwise, shoot
                        if (Bullets < 6)
                        {
                            Console.WriteLine(">> " + Name + " is reloading");
                            Reload();
                        }
                        else
                        {
                            Console.WriteLine(">> {0} shoots!", Name);
                            if (Shoot(range))
                            {
                                Console.WriteLine(">> {0} has been hit", player.Name);
                                player.Health--;
                            }
                            else
                            {
                                Console.WriteLine(">> {0} missed you!", Name);
                            }
                        }
                        break;
                    default: //otherwise, shoot revolver
                        Console.WriteLine(">> {0} shoots!", Name);
                        if (Shoot(range))
                        {
                            Console.WriteLine(">> {0} has been hit", player.Name);
                            player.Health--;
                        }
                        else
                        {
                            Console.WriteLine(">> {0} missed you!", Name);
                        }
                        break;
                }
            }

            return range;
        }



    }
}
