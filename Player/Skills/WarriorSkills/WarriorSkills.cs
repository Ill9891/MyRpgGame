using System;
using System.Collections.Generic;

namespace MyRpgGame.Player.Skills.WarriorSkills
{
    public class WarriorSkills
    {
        List<ISkills> ListOfWarriorSkills = new List<ISkills>();

        PowerStrike powerStrike = new PowerStrike();
        Defence defence = new Defence();

        public List<ISkills> GetWarriorSkills()
        {
            ListOfWarriorSkills.Add(powerStrike);
            ListOfWarriorSkills.Add(defence);

            return ListOfWarriorSkills;
        }
    }
}
