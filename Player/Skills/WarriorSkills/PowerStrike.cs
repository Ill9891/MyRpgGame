using MyRpgGame.Enemy;

namespace MyRpgGame.Player.Skills.WarriorSkills
{
    public class PowerStrike : ISkills
    {
        public string Name { get { return "Power Strike"; } }
        public double Damage { get { return 4; } }

        public void Execute(Character player, AbstractEnemy enemy)
        {
            double totalDamage = Damage + player.Level;
            enemy.HP -= totalDamage;
        }

        public string Description()
        {
            string desc = "Наносите урон в 2 раза мощнее обычного";
            return desc;
        }


    }
}
