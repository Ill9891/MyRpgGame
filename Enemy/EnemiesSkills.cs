
namespace MyRpgGame.Enemy
{
    public class EnemiesSkills
    {
        SkillsFactory skillsFactory = new SkillsFactory();
        Skill[] enemiesKillsArray = new Skill[5];

        public Skill[] CreateEnemySkill()
        {
            Skill smash = skillsFactory.GetSkills("Smash", "Мощный удар дубиной по голове", 7);
            enemiesKillsArray[0] = smash;
            Skill axeWound = skillsFactory.GetSkills("Axe Wound", "Мощный удар топором", 4);
            enemiesKillsArray[1] = axeWound;
            Skill powerShot = skillsFactory.GetSkills("Power Shot", "Мощный выстрел из лука", 5);
            enemiesKillsArray[2] = powerShot;
            Skill poisonShot = skillsFactory.GetSkills("Spear Shot", "Отравленный копья", 4);
            enemiesKillsArray[3] = poisonShot;
            Skill wildWind = skillsFactory.GetSkills("Wild Wind", "Насылает на вас мощный ветер", 4);
            enemiesKillsArray[4] = wildWind;
            return enemiesKillsArray;
        }
    }
}
