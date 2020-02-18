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

        // constructor (SPAWNER)
        public Day()
        {

        }
        // member methods (CAN DO)
        public void WeatherChooser()
        {
            weatherRandomizer = new Random().Next(1,11);
            if (weatherRandomizer == 1)
            {
                MakeRainy();
                Console.WriteLine("The weather today will be Rainy and the temperature will be " + temperature + " F°.");
            }
            else if (weatherRandomizer == 2)
            {
                MakeCloudy();
                Console.WriteLine("The weather today will be Cloudy and the temperature will be " + temperature + " F°.");
            }
            else
            {
                MakeSunny();
                Console.WriteLine("The weather today will be Sunny and the temperature will be " + temperature + " F°.");
            }
        }
        private void MakeSunny()
        {
            temperature = new Random().Next(80, 100);
            condition = "Sunny";
        }
        private void MakeCloudy()
        {
            temperature = new Random().Next(70, 80);
            condition = "Cloudy";
        }
        private void MakeRainy()
        {
            temperature = new Random().Next(60, 70);
            condition = "Raining";
        }
    }
}
