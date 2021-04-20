using System.Collections.Generic;
namespace MyRpgGame.Player.Skills.ArcherSkills
{
    public class ArcherSkills
    {
        List<ISkills> ListOfArcherSkills = new List<ISkills>();

        PoisonShot jumpBack = new PoisonShot();
        PowerShot powerShot = new PowerShot();

        public List<ISkills> GetArcherSkills()
        {
            ListOfArcherSkills.Add(jumpBack);
            ListOfArcherSkills.Add(powerShot);

            return ListOfArcherSkills;
        }

    }
}
