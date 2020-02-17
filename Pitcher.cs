using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Pitcher
    {
        // member variables (HAS A)
        //public List<Pitcher> pitchers;
        public int cupsRemaining;
        Recipe newRecipe;
        // constructor (SPAWNER)
        public Pitcher(Player player)
        {
            newRecipe = new Recipe(player);
            cupsRemaining = 25;
        }

        // member methods (CAN DO)

    }
}
