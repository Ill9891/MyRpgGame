using System;
using System.Collections.Generic;
using MyRpgGame.Player.Skills.WarriorSkills;

namespace MyRpgGame.Player.Specs
{
    public class Warrior : ISpec
    {
        public string SpecName { get; set; }
        public double Damage { get; set; }
        public double HP { get; set; }

        public List<Skills.ISkills> Skills()
        {
            WarriorSkills warriorSkills = new WarriorSkills();
            var skills = warriorSkills.GetWarriorSkills();

            for (int i = 0; i < skills.Count; i++)
            {
                Console.WriteLine($"{i + 1}:");
                Console.WriteLine(skills[i].Description());
            }
            return skills;
        }

        public Warrior()
        {
            SpecName = "Warrior";
            Damage = 2;
            HP = 12;
        }
    }
}
