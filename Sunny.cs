using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Sunny : Weather
    {
        // member variables (HAS A)

        // constructor (SPAWNER)
        public Sunny()
        {
            temperature = new Random().Next(80, 100);
            condition = "Sunny";
        }
        // member methods (CAN DO)

    }
}
