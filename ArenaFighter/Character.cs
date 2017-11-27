using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Character
    {
        private string _name;                   
        public int Strength { get; set; }
        public int Health { get; set; }
        public int RoundHealth { get; set; }
        List<string> Log = new List<string>();
        List<string> OpponentNames = new List<string> {"Donald Trump", "Tjock Norris", "Bruus Lii", "Ogabogah", "Batman", "Cartman", "Kenny", "Neo", "Mr Smith", "Onyxia", "El Guapo", "Dr Evil"};
        List<string> OpponentTitles = new List<string> { "murloc", "lame", "badass", "stinker", "deadly", "whiner", "ass kikker", "walking dead", "breath of death", "ugly", "horny", "smelly one" };

        public void InputCharacterStats()
        {
            int difficulty = 0;
            Console.Write("Please enter your champions name: ");
            GetNameFromConsole();
            Console.Write("Enter difficulty level 1=Nightmare!, 2=Ultra violence, 3=Hurt me plenty, 4=Hey, not too rough, 5=I'm too young to die: ");
            difficulty = Convert.ToInt32(GetNumberFromConsole(1,5));
            SetRandomStatsOnDifficulty(difficulty);
            PrintPlayerInfo();
        }

        public void generateOpponent()
        {
            Random Rand = new Random();
            this.Name = OpponentNames[Rand.Next(0,OpponentNames.Count-1)] + " the " +OpponentTitles[Rand.Next(0,OpponentTitles.Count-1)];
            this.Strength = Rand.Next(6, 11);
            this.Health = Rand.Next(6, 11);
        }

        public void PrintPlayerInfo()
        {
            Console.WriteLine("Champion information:\nName: " + this.Name + "\nHealth: " + this.Health + "\nStrength: " + this.Strength);
        }

        public void SetRandomStatsOnDifficulty(int difficulty)
        {
            Random Rand = new Random();
            Console.WriteLine("Generating random stats based on selected difficulty level...");
            this.Strength = Rand.Next(5,9) + difficulty;    // set strength to random value between 5 and 9 plus difficulty number.
            this.Health = Rand.Next(5,9) + difficulty;      // same for health
        }

        public void PrintLog()
        {
            Console.WriteLine("\nYour battle log:");
            this.Log.ForEach(Console.WriteLine);
        }

            public void AppendLogAndPrint(string newPost)
        {
            this.Log.Add(newPost);
            Console.WriteLine(newPost);
        }

        public string Name      
        {
            get { return _name; }
            set
            {
                if (value.Length < 30 && value.Length > 2)
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
