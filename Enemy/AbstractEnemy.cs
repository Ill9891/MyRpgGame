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
            Console.WriteLine($"Тип - {EnemyType}");
            Console.WriteLine($"Имя - {Name}");
            Console.WriteLine($"Уровень - {Lvl}");
            Console.WriteLine($"Жизнь - {HP}");
            Console.WriteLine($"Урон - {Damage}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

