
namespace MyRpgGame.Enemy
{
    public class EnemiesSkills
    {
        SkillsFactory skillsFactory = new SkillsFactory();
        Skill[] enemiesKillsArray = new Skill[5];

        public Skill[] CreateEnemySkill()
        {
            Skill smash = skillsFactory.GetSkills("Smash", "Powerful clubbing to the head", 7);
            enemiesKillsArray[0] = smash;
            Skill axeWound = skillsFactory.GetSkills("Axe Wound", "Powerful axe blow", 4);
            enemiesKillsArray[1] = axeWound;
            Skill powerShot = skillsFactory.GetSkills("Power Shot", "Powerful bow shot", 5);
            enemiesKillsArray[2] = powerShot;
            Skill poisonShot = skillsFactory.GetSkills("Spear Shot", "Poisoned Spear", 4);
            enemiesKillsArray[3] = poisonShot;
            Skill wildWind = skillsFactory.GetSkills("Wild Wind", "Sends a powerful wind at youр", 4);
            enemiesKillsArray[4] = wildWind;
            return enemiesKillsArray;
        }
    }
}
