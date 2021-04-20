
namespace MyRpgGame.Enemy
{
    public class EnemyFactory
    {
        public AbstractEnemy CreateEnemy(string enemyType, string name, int lvl, double hp, double damage, Skill skill, int battleNum, double exp)
        {
            AbstractEnemy enemy = new AbstractEnemy();

            enemy.EnemyType = enemyType;
            enemy.Name = name;
            enemy.Lvl = lvl;
            enemy.HP = hp;
            enemy.Damage = damage;
            enemy.Experience = exp;
            enemy.battleCells[battleNum] = skill;

            return enemy;
        }
    }
}
