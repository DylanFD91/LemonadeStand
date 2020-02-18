using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    static class UserInterface
    {
        public static int GetNumberOfItems(string itemsToGet)//Item purchasing method used with store class
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }
        public static void DisplayCurrentInventoryAndMoney(Player player)//Displays the wallet and inventory of the player
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Wallet: $" + player.wallet.Money);
            Console.WriteLine("Inventory: ");
            Console.WriteLine("Lemons: " + player.inventory.lemons.Count);
            Console.WriteLine("Sugar Cubes: " + player.inventory.sugarCubes.Count);
            Console.WriteLine("Ice Cubes: " + player.inventory.iceCubes.Count);
            Console.WriteLine("Cups: " + player.inventory.cups.Count);
            Console.WriteLine("-----------------------\n");
            Console.ReadLine();
        }
        public static void StorePriceList(Store store)
        {
            Console.WriteLine("\n----------------------------------------------------");
            Console.WriteLine("Here is a list of my goods and there current prices:");
            Console.WriteLine("Lemons: $" + store.pricePerLemon);
            Console.WriteLine("Sugar Cubes: $" + store.pricePerSugarCube);
            Console.WriteLine("Ice Cubes: $" + store.pricePerIceCube);
            Console.WriteLine("Cups: $" + store.pricePerCup);
            Console.WriteLine("----------------------------------------------------\n");
        }
        public static void WelcomeToGame()
        {
            Console.WriteLine("Welcome to your lemonade stand.");
            Console.ReadLine();
        }
        public static void DisplayRules()
        {
            Console.WriteLine("you run a lemonade stand and you can buy supplies from a local store, try to sell as much as you can in seven days.");
            Console.ReadLine();
        }
        public static void DisplayDaysWeather(Day day)//Randomly chooses weather and outputs the current status of the day.
        {
            day = new Day();
            day.WeatherChooser();
            Console.ReadLine();
        }



    }
}
