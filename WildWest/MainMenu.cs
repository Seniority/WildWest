using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WildWest
{
    class MainMenu
    {
        int range; //distance between fighters
        Duelist player; //human player
        AIDuelist opponent; //ai opponent
        bool keepGoing = true; //controls main loop

        static void Main(string[] args)
        {
            MainMenu mm = new MainMenu();
        }

        public MainMenu()
        {
            int choice;
            string name;

            Console.Write("What is your name?: ");
            name = Console.ReadLine();
            player = new Duelist(name);
            Console.Write("What is your opponent's name?: ");
            name = Console.ReadLine();
            opponent = new AIDuelist(player, name);
            range = 10;

            while (keepGoing)
            {
                choice = DisplayMenu();
                switch (choice)
                {
                    case 0: //Quit
                        Console.WriteLine("Quit");
                        keepGoing = false;
                        break;
                    case 1: //Reload bullets
                        player.Reload();
                        if (player.Bullets >= 6)
                        {
                            player.Bullets = 6;
                        }
                        break;
                    case 2: //Move closer
                        range--;
                        if (range < 0)
                        {
                            range = 0;
                        }
                        break;
                    case 3: //Move away
                        range++;
                        break;
                    case 4: //Shoot
                        if (player.Shoot(range))
                        {
                            Console.WriteLine(">> You hit {0}!", opponent.Name);
                            opponent.Health--;
                        }
                        else
                        {
                            Console.WriteLine(">> You missed {0}!", opponent.Name);
                        }
                        break;
                    default:
                        Console.WriteLine(">> You said {0}. Nothing happens.", choice);
                        break;
                }

                range = opponent.ChoosePlay(range);

                CheckWinner();
            }
        }

        public void CheckWinner() //Check to see if someone has died yet
        {
            string answer = "";

            if (opponent.Health <= 0) //excute this code if opponent dies
            {
                Console.WriteLine(">> " + opponent.Name + " has died");
                Console.WriteLine("You win! Would you like to play again? (Y/N) ");
                answer = Console.ReadLine();
                if (answer.ToUpper() == "N" || answer.ToUpper() == "NO")
                {
                    keepGoing = false;
                }
                else if (answer.ToUpper() == "Y" || answer.ToUpper() == "YES")
                {
                    RestartGame();
                }
                else
                {
                    Console.WriteLine("Not a valid answer. Closing Application...");
                }

            }
            else if (player.Health <= 0) //execute this code if player dies
            {
                Console.WriteLine(">> " + player.Name + " has died");
                Console.Write("You have been defeated! Would you like to play again? (Y/N) ");
                answer = Console.ReadLine();
                if (answer.ToUpper() == "N" || answer.ToUpper() == "NO")
                {
                    keepGoing = false;
                }
                else if (answer.ToUpper() == "Y" || answer.ToUpper() == "YES")
                {
                    RestartGame();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("<< Not a valid answer. Closing Application... >>");
                    Thread.Sleep(2300);
                    keepGoing = false;
                }
            }
        }

        public int DisplayMenu()
        {
            int choice;
            Console.WriteLine();
            Console.WriteLine("===============");            
            Console.WriteLine("Stats:");
            Console.WriteLine("  Distance: {0}", range);
            Console.WriteLine("  Bullets: {0}", player.Bullets);
            Console.WriteLine("  {0}'s Health: {1}", player.Name, player.Health);
            Console.WriteLine("  {0}'s Health: {1}", opponent.Name, opponent.Health);
            Console.WriteLine();
            Console.WriteLine("1> Reload");
            Console.WriteLine("2> Move closer");
            Console.WriteLine("3> Move away");
            Console.WriteLine("4> Shoot");
            Console.WriteLine("0> Quit");
            Console.WriteLine();

            Console.Write("Indicate your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("===============");
            Console.WriteLine();
            return choice;
        }

        public void RestartGame() //reset Duelist properties if player wants to play again
        {
            player.Health = 5;
            player.Bullets = 6;
            opponent.Health = 5;
            opponent.Bullets = 6;
            range = 10;
        }
    }
}
