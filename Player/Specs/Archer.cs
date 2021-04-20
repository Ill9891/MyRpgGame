using System;
using System.Collections.Generic;
using MyRpgGame.Player.Skills.ArcherSkills;

namespace MyRpgGame.Player.Specs
{
    public class Archer : ISpec
    {
        public string SpecName { get; set; }
        public double Damage { get; set; }
        public double HP { get; set; }

        public List<Skills.ISkills> Skills()
        {
            ArcherSkills archerSkills = new ArcherSkills();
            var skills = archerSkills.GetArcherSkills();

            for (int i = 0; i < skills.Count; i++)
            {
                Console.WriteLine($"{i + 1}:");
                Console.WriteLine(skills[i].Description());
            }
            return skills;
        }

        public Archer()
        {
            SpecName = "Archer";
            Damage = 3;
            HP = 7;
        }

    }
}
