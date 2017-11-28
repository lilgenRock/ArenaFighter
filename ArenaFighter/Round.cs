using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Round
    {
        public static Random Rand = new Random();
        public bool DoRound(Character player, Character opponent)
        {
            //Random Rand = new Random();
            int playerRoundStrength = player.Strength + Rand.Next(1, 6) -4;         // lowering strength by 4 to deal less damage and getting more rounds.
            int opponentRoundStrength = opponent.Strength + Rand.Next(1, 6) -4;
            string actionString = "";
            if (playerRoundStrength > opponentRoundStrength)
            {
                opponent.RoundHealth -= playerRoundStrength / 2;        // Player does damage to opponent
                actionString = "You attack " + opponent.Name + " dealing " + playerRoundStrength / 2 + " damage lowering his health to " + ((opponent.RoundHealth >= 0) ? opponent.RoundHealth : 0) + ".";
            }
            else if(playerRoundStrength < opponentRoundStrength)
            {
                player.RoundHealth -= opponentRoundStrength / 2;        // opponent does damage to player
                actionString = opponent.Name + " attacks you dealing " + opponentRoundStrength / 2 + " damage lowering your health to " + ((player.RoundHealth >= 0) ? player.RoundHealth : 0) + ".";
            }
            else                                                        // stand off. no damage done by either
            {
                actionString = "No attack was made. Unpleasant insults were made instead.";
            }

            player.AppendLogAndPrint(actionString);
            if(player.RoundHealth > 0 && opponent.RoundHealth > 0)
            {
                return true;        // both still alive and kicking? then return true and continue fighting
            }
            else
            {
                return false;       // someone died and fight is over. return false to stop.
            }
        }
    }
}
