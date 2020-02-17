using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    public class Weather
    {
        // member variables (HAS A)
        public double temperature;
        public string condition;

        // constructor (SPAWNER)
        public Weather()
        {

        }
        // member methods (CAN DO)
        public void MakeSunny()
        {
            temperature = new Random().Next(80, 100);
            condition = "Sunny";
        }
        public void MakeCloudy()
        {
            temperature = new Random().Next(70, 80);
            condition = "Cloudy";
        }
        public void MakeRainy()
        {
            temperature = new Random().Next(60, 70);
            condition = "Raining";
        }
    }
}
