using MyRpgGame.Enemy;

namespace MyRpgGame.Player.Skills.ArcherSkills
{
    public class PoisonShot : ISkills
    {
        public string Name { get { return "Poison Shot"; } }
        public double Damage { get { return 0; } }

        public void Execute(Character player, AbstractEnemy enemy)
        {
            enemy.Damage /= 2;
        }
        public string Description()
        {
            string desc = "Poison an enemy, reducing its current damage by 2.";
            return desc;
        }
    }
}