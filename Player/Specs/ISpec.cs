using System.Collections.Generic;

namespace MyRpgGame.Player.Specs
{
    public interface ISpec
    {
        string SpecName { get; set; }
        double Damage { get; set; }
        double HP { get; set; }

        List<Skills.ISkills> Skills();

    }
}
