using System;

namespace MyRpgGame.Enemy
{
    public class AbstractEnemy
    {
        public Skill[] battleCells = new Skill[10];
        public string EnemyType;
        public string Name;
        public int Lvl;
        public double HP;
        public double Damage;
        public double Experience;


        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Type - {EnemyType}");
            Console.WriteLine($"Name - {Name}");
            Console.WriteLine($"Level - {Lvl}");
            Console.WriteLine($"HP - {HP}");
            Console.WriteLine($"Damage - {Damage}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

