
namespace MyRpgGame.Enemy
{
    public class ElfFactory
    {
        EnemiesSkills enemySkill = new EnemiesSkills();
        EnemyFactory factory = new EnemyFactory();
        AbstractEnemy[] elfssList = new AbstractEnemy[4];

        public AbstractEnemy CreateElf(int random)
        {
            Skill[] elfSkills = enemySkill.CreateEnemySkill();

            AbstractEnemy elfScout = factory.CreateEnemy(enemyType: "Elf", name: "Elf scout", lvl: 1, hp: 7, damage: 2, skill: elfSkills[2], battleNum: random, exp: 2);
            elfssList[0] = elfScout;
            AbstractEnemy elfRanger = factory.CreateEnemy(enemyType: "Elf", name: "Elf ranger", lvl: 1, hp: 10, damage: 2, skill: elfSkills[2], battleNum: random, exp: 3);
            elfssList[1] = elfRanger;
            AbstractEnemy Driada = factory.CreateEnemy(enemyType: "Elf", name: "Driada", lvl: 1, hp: 10, damage: 3, skill: elfSkills[3], battleNum: random, exp: 4);
            elfssList[2] = Driada;
            AbstractEnemy highElf = factory.CreateEnemy(enemyType: "Elf", name: "High elf", lvl: 1, hp: 12, damage: 1.7, skill: elfSkills[4], battleNum: random, exp: 4);
            elfssList[3] = highElf;

            return elfssList[random];
        }
    }
}
