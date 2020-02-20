using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    public class Day
    {
        // member variables (HAS A)
        public double temperature;
        public string condition;
        private int weatherRandomizer;
        public int dayNumber;
        Random random;

        // constructor (SPAWNER)
        public Day(Random random)
        {
            this.random = random;
            WeatherChooser();
        }

        // member methods (CAN DO)
        public void WeatherChooser()
        {
            weatherRandomizer = random.Next(1, 11);
            if (weatherRandomizer == 1)
            {
                MakeRainy();
            }
            else if (weatherRandomizer == 2)
            {
                MakeCloudy();
            }
            else
            {
                MakeSunny();
            }
        }
        private void MakeSunny()
        {
            temperature = random.Next(80, 100);
            condition = "Sunny";
        }
        private void MakeCloudy()
        {
            temperature = random.Next(70, 80);
            condition = "Cloudy";
        }
        private void MakeRainy()
        {
            temperature = random.Next(60, 70);
            condition = "Raining";
        }
    }
}
