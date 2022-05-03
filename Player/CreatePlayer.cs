using System;
using MyRpgGame.Player.Specs;

namespace MyRpgGame.Player
{
    public class CreatePlayer
    {
        Character player;
        ListOfSpecs listOfSpecs = new ListOfSpecs();


        public Character NewPlayer()
        {
            var specs = listOfSpecs.GetSpecs();

            Console.Write("Enter your character name and press Enter: ");
            string name = Console.ReadLine();
            Console.Clear();

            ChooseSpec:
            Console.Write("Select your character class by selecting the appropriate number and press Enter: \n");
            for (int i = 0; i < specs.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {specs[i].SpecName}");
            }
            int chosenSpec = Convert.ToInt16(Console.ReadLine());

            if (chosenSpec < 0 || chosenSpec > specs.Count)
            {
                Console.Clear();
                goto ChooseSpec;
            }

            Console.Clear();

            player = new Character(name, specs[chosenSpec - 1]);

            Console.WriteLine("We welcome you " + player.Name);
            Console.WriteLine("In this game, you alternate with the enemy \"throw the die\", the value can fall from 1 to 10.");
            Console.WriteLine("You have 10 empty cells, respectively. If the die value matches an empty cell, then you deal your base damage.");
            Console.WriteLine("If the value matches the slot in which you placed the skill, then skill damage is dealt. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            return player;
        }
    }
}
