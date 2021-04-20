using System.Collections.Generic;
using MyRpgGame.Player.Specs;

namespace MyRpgGame.Player
{
    public class SkillAdder
    {
        public List<Skills.ISkills> GetSkill(Character player)
        {
            List<Skills.ISkills> skillList = new List<Skills.ISkills>();
            ListOfSpecs listOfSpecs = new ListOfSpecs();

            var specList = listOfSpecs.GetSpecs();

            foreach (var spec in specList)
            {
                if (spec.SpecName == player.Spec)
                {
                    var newSpec = spec;
                    skillList = spec.Skills();
                }
            }

            return skillList;
        }
    }
}
