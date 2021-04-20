using System;
using System.Threading;
using MyRpgGame.Enemy;
using MyRpgGame.Player;

namespace MyRpgGame
{
    public class Messages
    {
        Random random = new Random();
        CreatePlayer createPlayer;
        Character player;
        AbstractEnemy enemy;
        Locations location = new Locations();
        int choosenSkill;
        int choosenCell;
        int roll;
        int randomEnemy;

        public void CharCreation()
        {
            player = createPlayer.NewPlayer();
        }

        public void ChooseLocation(Character player)
        {
            Label:
            Console.WriteLine("Итак, выберите локацию куда бы вы хотели пойти, Лес под номером 1, Степи под номером 2.");
            var loc = Console.ReadLine();
            if (loc == "1")
            {
                location.Forest(player);
            }
            else if (loc == "2")
            {
                location.Steppe(player);
            }
            else
            {
                Console.WriteLine("Вы нажали не верную клавишу");
                Console.ReadKey();
                Console.Clear();
                goto Label;
            }
        }

        public void ChooseYourSkill(Character player)
        {

            SkillAdder skill = new SkillAdder();

            Console.ForegroundColor = ConsoleColor.Gray;

            ChooseSkill:
            Console.WriteLine("\nВыберите умение нажав соответствующую цифру:");
            var skills = skill.GetSkill(player);
            choosenSkill = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();

            if (choosenSkill < 0 || choosenSkill > skills.Count)
                goto ChooseSkill;

            ChooseCell:
            Console.WriteLine("Расположите умение в ячейку, выберите номер от 1 до 10:");
            choosenCell = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();

            if (choosenCell < 0 || choosenCell > 10)
                goto ChooseCell;

            player.SkillCells[choosenCell] = skills[choosenSkill];
        }

        public void MeetEnemy(Character player)
        {
            randomEnemy = random.Next(0, 4);

            if (player.Location == "Steppe")
            {
                OrcFactory orcFactory = new OrcFactory();
                enemy = orcFactory.CreateOrk(randomEnemy);

            }
            else if (player.Location == "Forest")
            {
                ElfFactory elfFactory = new ElfFactory();
                enemy = elfFactory.CreateElf(randomEnemy);
            }

            Console.WriteLine("Против вас:\n");
            enemy.Show();
        }

        public void Fight(Character player)
        {
            while (player.HP > 0 || enemy.HP > 0)
            {
                Label:
                player.Show();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(player.SkillCells[choosenCell].Name + " в ячейке номер " + (choosenCell + 1) + " с уроном " + player.SkillCells[choosenCell].Damage);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nпротив\n");

                enemy.Show();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.battleCells[randomEnemy].name + " в ячейке номер " + (randomEnemy) + " с уроном " + enemy.battleCells[randomEnemy].damage);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("\nНажмите клавишу R на английской раскладке что бы совершить бросок кубика. ");

                string rollDice = Console.ReadLine();
                if (rollDice == "r" || rollDice == "R")
                {
                    roll = random.Next(1, 11);

                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.WriteLine("Вы выкинули " + roll);
                    if (player.SkillCells[roll - 1] == null)
                    {
                        enemy.HP -= player.Damage;
                        Console.WriteLine("\nВы нанесли врагу " + player.Damage + " урона!");
                    }
                    else
                    {
                        player.SkillCells[roll - 1].Execute(player, enemy);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nВы нанесли врагу " + player.SkillCells[roll - 1].Damage + " урона с помощью " + player.SkillCells[roll - 1].Name);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Thread.Sleep(1000);
                    Console.WriteLine("\nБросает враг...\n");
                    roll = random.Next(1, 11);
                    Thread.Sleep(1000);
                    Console.WriteLine("Враг выкинул " + roll);
                    if (enemy.battleCells[roll - 1] == null)
                    {
                        player.HP -= enemy.Damage;
                        Console.WriteLine("\nВраг нанес вам " + enemy.Damage + " урона!");
                    }
                    else
                    {
                        player.HP -= enemy.battleCells[roll - 1].damage;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nВраг нанес вам " + enemy.battleCells[roll - 1].damage + " урона с помощью " + enemy.battleCells[roll - 1].name);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    Console.Clear();
                    goto Label;
                }
                if (player.HP <= 0 || enemy.HP <= 0)
                {
                    break;
                }
            }


            if (enemy.HP <= 0 && player.HP > 0)
            {
                Console.WriteLine("Вы победили!");

                player.Experience += enemy.Experience;

                player.HP = player.CurrentHP;
                player.Armor = player.CurrentArmor;
                player.Damage = player.CurrentDamage;
            }
            else if (player.HP <= 0 && enemy.HP > 0)
            {
                Console.WriteLine("Вы проиграли!");

                player.HP = player.CurrentHP;
                player.Armor = player.CurrentArmor;
                player.Damage = player.CurrentDamage;
            }
            else
            {
                Console.WriteLine("Ничья!");

                player.HP = player.CurrentHP;
                player.Armor = player.CurrentArmor;
                player.Damage = player.CurrentDamage;
            }
        }

    }
}
