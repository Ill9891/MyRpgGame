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
            Console.WriteLine("So, choose the location where you would like to go, Forest number 1, Steppe number 2.");
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
                Console.WriteLine("You pressed the wrong key");
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
            Console.WriteLine("\nSelect a skill by entering the appropriate number:");
            var skills = skill.GetSkill(player);
            choosenSkill = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();

            if (choosenSkill < 0 || choosenSkill > skills.Count)
                goto ChooseSkill;

            ChooseCell:
            Console.WriteLine("Place the skill in a cell, select a number from 1 to 10:");
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

            Console.WriteLine("Against you:\n");
            enemy.Show();
        }

        public void Fight(Character player)
        {
            while (player.HP > 0 || enemy.HP > 0)
            {
                Label:
                player.Show();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(player.SkillCells[choosenCell].Name + " in cell number " + (choosenCell + 1) + " with damage " + player.SkillCells[choosenCell].Damage);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nagainst\n");

                enemy.Show();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.battleCells[randomEnemy].name + " in cell number " + (randomEnemy) + " with damage " + enemy.battleCells[randomEnemy].damage);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("\nPress the R key to roll the die. ");

                string rollDice = Console.ReadLine();
                if (rollDice == "r" || rollDice == "R")
                {
                    roll = random.Next(1, 11);

                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.WriteLine("You have rolled " + roll);
                    if (player.SkillCells[roll - 1] == null)
                    {
                        enemy.HP -= player.Damage;
                        Console.WriteLine("\nYou have dealt " + player.Damage + " damage to the enemy!");
                    }
                    else
                    {
                        player.SkillCells[roll - 1].Execute(player, enemy);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nYou have dealt " + player.SkillCells[roll - 1].Damage + " damage to the enemy with " + player.SkillCells[roll - 1].Name);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Thread.Sleep(1000);
                    Console.WriteLine("\nEnemy is rolling...\n");
                    roll = random.Next(1, 11);
                    Thread.Sleep(1000);
                    Console.WriteLine("Enemy has rolled " + roll);
                    if (enemy.battleCells[roll - 1] == null)
                    {
                        player.HP -= enemy.Damage;
                        Console.WriteLine("\nEnemy has dealt " + enemy.Damage + " damage to you!");
                    }
                    else
                    {
                        player.HP -= enemy.battleCells[roll - 1].damage;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nEnemy has dealt " + enemy.battleCells[roll - 1].damage + " damage to you with " + enemy.battleCells[roll - 1].name);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.WriteLine("\nPress any key to continue");
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
                Console.WriteLine("You won!");

                player.Experience += enemy.Experience;

                player.HP = player.CurrentHP;
                player.Armor = player.CurrentArmor;
                player.Damage = player.CurrentDamage;
            }
            else if (player.HP <= 0 && enemy.HP > 0)
            {
                Console.WriteLine("You lost!");

                player.HP = player.CurrentHP;
                player.Armor = player.CurrentArmor;
                player.Damage = player.CurrentDamage;
            }
            else
            {
                Console.WriteLine("Tie!");

                player.HP = player.CurrentHP;
                player.Armor = player.CurrentArmor;
                player.Damage = player.CurrentDamage;
            }
        }

    }
}
