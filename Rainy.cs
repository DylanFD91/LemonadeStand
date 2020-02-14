using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Rainy : Weather
    {
        // member variables (HAS A)

        // constructor (SPAWNER)
        public Rainy()
        {
            temperature = new Random().Next(60,70);
            condition = "Raining";
        }

        // member methods (CAN DO)

    }
}
