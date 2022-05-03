using MyRpgGame.Enemy;

namespace MyRpgGame.Player.Skills.WarriorSkills
{
    public class Defence : ISkills
    {
        public string Name { get { return "Defence"; } }
        public double Damage { get { return 0; } }

        public double additionalArmor = 1;

        public void Execute(Character player, AbstractEnemy enemy)
        {
            player.CurrentArmor += additionalArmor;
        }

        public string Description()
        {
            string desc = "Adds 1 defense until end of combat";
            return desc;
        }
    }
}
