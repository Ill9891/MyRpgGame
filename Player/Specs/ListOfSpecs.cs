using System.Collections.Generic;

namespace MyRpgGame.Player.Specs
{
    public class ListOfSpecs
    {
        List<ISpec> specList = new List<ISpec>();

        Archer archer = new Archer();
        Warrior warrior = new Warrior();

        public List<ISpec> GetSpecs()
        {
            specList.Add(archer);
            specList.Add(warrior);

            return specList;
        }
    }
}
