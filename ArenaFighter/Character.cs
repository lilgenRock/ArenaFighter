using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Character
    {
        private string _name;                   //public string Name{ get; set;}
        public int Strength { get; set; }
        public int Health { get; set; }

        public void InputCharacterStats()
        {
            int difficulty = 0;
            Console.Write("Please enter your champions name: ");
            GetNameFromConsole();
            Console.WriteLine("Enter difficulty level 1=Nightmare!, 2=Ultra violence, 3=Hurt me plenty, 4=Hey, not too rough, 5=I'm too young to die: ");
            difficulty = Convert.ToInt32(GetNumberFromConsole(1,5));
            SetRandomStatsOnDifficulty(difficulty);
            PrintPlayerInfo();
        }

        public void PrintPlayerInfo()
        {
            Console.WriteLine("Champion information:\nName: " + this.Name + "\nHealth: " + this.Health + "\nStrength: " + this.Strength);
        }

        public void SetRandomStatsOnDifficulty(int difficulty)
        {
            Random Rand = new Random();
            this.Strength = Rand.Next(5,9) + difficulty;    // set strength to random value between 5 and 9 plus difficulty number.
            this.Health = Rand.Next(5,9) + difficulty;     // same for health
        }

        public string Name      
        {
            get { return _name; }
            set
            {
                if (value.Length < 11 && value.Length > 2)
                    _name = value;
                else
                {
                    Console.WriteLine("Invalid name length. 3-10 characters allowed.");
                }
            }
        }

        public void GetNameFromConsole()
        {
            string str = null;
            while (this.Name == null)
            {
                str = Console.ReadLine();
                this.Name = str;
            }
        }

        public double GetNumberFromConsole(int min = 0, int max = 0)
        {
            double num;
            bool interval = false;
            if(min != 0 || max != 0)
            {
                interval = true;
            }
            while (true)
            {
                try
                {
                    num = Convert.ToDouble(Console.ReadLine());
                    if (!interval || (interval && num >= min && num <= max))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Valid numbers are between " + min + " and " + max + ": ");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Input error. Try again.");
                }
            }
            return num;
        }

    }
}
