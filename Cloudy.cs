using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Cloudy : Weather
    {
        // member variables (HAS A)

        // constructor (SPAWNER)
        public Cloudy()
        {
            temperature = new Random().Next(70,80);
            condition = "Cloudy";
        }

        // member methods (CAN DO)

    }
}
