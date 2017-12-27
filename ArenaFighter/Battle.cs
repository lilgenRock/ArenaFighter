using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Battle
    {
        bool BattleContinues = true;
        int RoundCounter = 0;

        public bool DoBattle(Character c)
        {
            string input = "";
            Console.WriteLine("Press enter to start a new battle or x to exit: ");
            input = Console.ReadLine();
            if(input.ToLower().Equals("x"))
            {
                c.AppendLogAndPrint("Player is feeling old and grumpy. Retirement it is! ");
                return false;
            }
            Character o = new Character();
            o.generateOpponent();
            c.RoundHealth = c.Health;
            o.RoundHealth = o.Health;
            Console.WriteLine(c.Name + " vs " + o.Name  + ". You who are about to die, we salute you!\nPress enter to fight!");
            Console.ReadLine();
            while (BattleContinues)
            {
                Round r = new Round();
                RoundCounter++;
                Console.WriteLine("Round " + RoundCounter + ": ");
                BattleContinues = r.DoRound(c, o);
            }

            if(c.RoundHealth > 0)
            {
                return true;        // if player survived the battle he can contionue playing
            }
            else
            {
                c.AppendLogAndPrint("Oh no! You were killed by " + o.Name + "!");
                return false;       // return false if player is dead
            }            
        }
    }
}
