using System;
using System.Collections.Generic;

namespace Week10Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player();
            Enemy e = new Enemy();
            p.opponent = e;
            e.opponent = p;
            List<Fighter> fighters = new List<Fighter>();
            fighters.Add(p);
            fighters.Add(e);
            bool gameOver = false;
            foreach (Fighter f in fighters)
            {
                f.TakeAction();
            }
           while (!gameOver)
            {
                foreach (Fighter f in fighters)
                {
                    f.TakeAction();
                }
                if (e.hp <= 0)
                {
                    Console.WriteLine("The player has won!!!");
                    gameOver = true;
                }
                else if (p.hp <= 0)
                {
                    Console.WriteLine("The enemy has won :(");
                    gameOver = true;
                }
            }
        }
    }
    public class Fighter
    {
        public int hp = 20;
        public Fighter opponent;

        public virtual void TakeAction()
        {
        }
    }
    class Player : Fighter
    {
        int potCount = 3;

        public override void TakeAction()
        {


            bool valid = false;

            do
            {
                int pChoice;

                Console.WriteLine("Players Turn");
                Console.WriteLine("Players Health: " + hp);
                Console.WriteLine("Enemys Health: " + opponent.hp);
                Console.WriteLine("1. Fight\n2. Heal (" + potCount + " potions remaning)");

                pChoice = Convert.ToInt16(Console.ReadLine());
                if (pChoice == 1)
                {
                    Console.WriteLine("The player chooses attack!");
                    Console.WriteLine("Attacking the enemy for 2 points of damge");
                    Console.WriteLine("---------------------------------------");
                    opponent.hp -= 2;
                    valid = true;
                }
                else if (pChoice == 2)
                {

                    if (potCount > 0)
                    {
                        Console.WriteLine("The player chooses to heal!");
                        Console.WriteLine("Restored 2 health points to the player");
                        Console.WriteLine("---------------------------------------");
                        hp += 6;
                        potCount -= 1;
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("You are out of potions. Try again.");
                        valid = false;
                    }

                }
                else
                {
                    Console.WriteLine("Wrong input Try again.");
                }


            } while (valid == false);


        }
    }
    class Enemy : Fighter
    {
        public override void TakeAction()
        {
            Console.WriteLine("Enemys turn");
            Console.WriteLine("Players Health: " + opponent.hp);
            Console.WriteLine("Enemys Health: " + hp);
            Console.WriteLine("Enemy Attacks!");
            Console.WriteLine("Attacking the player for 3 points of damage");
            Console.WriteLine("---------------------------------------");
            opponent.hp -= 3;

        }
    }
}

    

