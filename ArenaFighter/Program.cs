using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    
    class Program
    {
        bool PlayerAlive = true;
        bool PlayerRetires = false;

        static void Main(string[] args)
        {
            Program p = new Program();
            Character c = new Character();
            StartGameMessage();
            c.InputCharacterStats();
            int Result = 0;
            while (p.PlayerAlive && !p.PlayerRetires)
            {
                Battle b = new Battle();
                Result = b.DoBattle(p, c);
            }


            EndGameMessage();
        }

        public static void StartGameMessage()
        {
            Console.WriteLine("Welcome to ArenaFighter!");
        }

        public static void EndGameMessage()
        {
            Console.WriteLine("Thanx you for playing ArenaFighter. Have a nice day!");
            Console.ReadLine();
        }

    }
}
