using MyRpgGame.Player;

namespace MyRpgGame
{
    public class Locations
    {
        public void Forest(Character player)
        {
            player.Location = "Forest";
        }

        public void Steppe(Character player)
        {
            player.Location = "Steppe";
        }
    }
}
