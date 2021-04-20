using System;
using MyRpgGame.Player.Skills;
using MyRpgGame.Player.Specs;

namespace MyRpgGame.Player
{
    public class Character
    {
        public ISkills[] SkillCells;

        public string Name { get; }
        public string Location { get; set; }
        public string Spec { get; }
        public double Damage { get; set; }
        public double CurrentDamage { get; set; }
        public double HP { get; set; }
        public double CurrentHP { get; set; }
        public int Level { get; set; } = 1;
        public double Experience { get; set; } = 0;
        public double Armor { get; set; } = 0;
        public double CurrentArmor { get; set; } = 0;

        void LevelUp()
        {
            if (Experience >= 100)
                Level += 1;
        }

        public Character(string newName, ISpec newSpec)
        {
            Name = newName;
            Spec = newSpec.SpecName;
            HP = newSpec.HP;
            CurrentHP = HP;
            Damage = newSpec.Damage;
            CurrentDamage = Damage;
            SkillCells = new ISkills[10];
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Имя - {Name}");
            Console.WriteLine($"Жизнь - {HP}");
            Console.WriteLine($"Броня - {Armor}");
            Console.WriteLine($"Урон - {Damage}");
            Console.WriteLine($"Локацuя - {Location}");
            Console.WriteLine($"Опыт - {Experience}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
