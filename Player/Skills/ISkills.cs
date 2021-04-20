using MyRpgGame.Enemy;

namespace MyRpgGame.Player.Skills
{
    public interface ISkills
    {
        string Name { get; }
        double Damage { get; }
        void Execute(Character player, AbstractEnemy enemy);
        string Description();
    }
}
