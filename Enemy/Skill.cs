using System;

namespace MyRpgGame.Enemy
{
    public class Skill
    {
        public string name;
        public string description;
        public double damage;

        public Skill(string name, string description, double damage)
        {
            this.name = name;
            this.description = description;
            this.damage = damage;
        }

        public void Show()
        {
            Console.WriteLine(name);
            Console.WriteLine($"Damage - {damage}");
            Console.WriteLine($"Description - {description}");
        }
    }

    public class SkillsFactory
    {
        public Skill GetSkills(string name, string description, double damage)
        {
            return new Skill(name, description, damage);
        }
    }
}

