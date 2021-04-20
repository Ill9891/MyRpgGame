
namespace MyRpgGame.Enemy
{
    public class OrcFactory
    {
        EnemiesSkills enemySkill = new EnemiesSkills();

        EnemyFactory factory = new EnemyFactory();
        AbstractEnemy[] orksList = new AbstractEnemy[4];

        public AbstractEnemy CreateOrk(int random)
        {
            Skill[] orkSkills = enemySkill.CreateEnemySkill();
            AbstractEnemy smallOrk = factory.CreateEnemy(enemyType: "Ork", name: "Small ork", lvl: 1, hp: 7, damage: 2, skill: orkSkills[1], battleNum: random, exp: 2);
            orksList[0] = smallOrk;
            AbstractEnemy middleOrk = factory.CreateEnemy(enemyType: "Ork", name: "Middle ork", lvl: 1, hp: 10, damage: 2, skill: orkSkills[1], battleNum: random, exp: 2);
            orksList[1] = middleOrk;
            AbstractEnemy bigOrk = factory.CreateEnemy(enemyType: "Ork", name: "Big ork", lvl: 1, hp: 10, damage: 3, skill: orkSkills[0], battleNum: random, exp: 3);
            orksList[2] = bigOrk;
            AbstractEnemy armoredOrk = factory.CreateEnemy(enemyType: "Ork", name: "Armored ork", lvl: 1, hp: 16, damage: 1.7, skill: orkSkills[1], battleNum: random, exp: 4);
            orksList[3] = armoredOrk;

            return orksList[random];
        }
    }
}
