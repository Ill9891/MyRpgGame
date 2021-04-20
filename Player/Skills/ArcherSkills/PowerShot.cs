using MyRpgGame.Enemy;

namespace MyRpgGame.Player.Skills.ArcherSkills
{
    public class PowerShot : ISkills
    {
        public string Name { get; set; } = "Power Shot";
        public double Damage { get; set; } = 4;

        public void Execute(Character player, AbstractEnemy enemy)
        {
            double totalDamage = Damage + player.Level;
            enemy.HP -= totalDamage;
        }

        public string Description()
        {
            string desc = "Наносите урон мощнее базового";
            return desc;
        }
    }
}
