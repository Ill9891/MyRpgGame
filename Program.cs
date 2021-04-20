using System;
using MyRpgGame.Enemy;
using MyRpgGame.Player;

namespace MyRpgGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CreatePlayer player = new CreatePlayer();

            Messages mess = new Messages();

            Character concretePlayer = player.NewPlayer();
            while (true)
            {
                mess.ChooseLocation(concretePlayer);
                mess.MeetEnemy(concretePlayer);
                mess.ChooseYourSkill(concretePlayer);
                mess.Fight(concretePlayer);
            }
        }
    }
}
