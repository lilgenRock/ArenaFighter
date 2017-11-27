using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Program
    {
        bool GameContinues = true;

        static void Main(string[] args)
        {
            Program p = new Program();
            Character c = new Character();
            StartGameMessage();
            c.InputCharacterStats();
            while (p.GameContinues)                     
            {
                Battle b = new Battle();
                p.GameContinues = b.DoBattle(p, c);     
            }
            c.PrintLog();
            EndGameMessage();
        }

        public static void StartGameMessage()
        {
            Console.WriteLine("Welcome to ArenaFighter!");
        }

        public static void EndGameMessage()
        {
            Console.WriteLine("Thanx for playing ArenaFighter. Have a nice day!");
            Console.ReadLine();
        }
    }
}
