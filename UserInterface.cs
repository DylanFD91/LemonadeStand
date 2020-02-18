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
        }
        public static void DisplayStorePriceList(Store store)//Displays the price list of the store
        {
            Console.WriteLine("\n----------------------------------------------------");
            Console.WriteLine("Here is a list of my goods and there current prices:");
            Console.WriteLine("Lemons: $" + store.pricePerLemon);
            Console.WriteLine("Sugar Cubes: $" + store.pricePerSugarCube);
            Console.WriteLine("Ice Cubes: $" + store.pricePerIceCube);
            Console.WriteLine("Cups: $" + store.pricePerCup);
            Console.WriteLine("----------------------------------------------------\n");
        }
        public static void WelcomeToGame()//Simple welcome keeping it seperate from rules to the rules can be called on throughout game
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|Welcome to the Lemonade Stand game!|");
            Console.WriteLine("-------------------------------------");
        }
        public static void DisplayRules()
        {
            Console.WriteLine("you run a lemonade stand and you can buy supplies from a local store, try to sell as much as you can in seven days.");
            UserInterface.PressEnterToContinue();
        }
        public static void PressEnterToContinue()
        {
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("Press (Enter) to continue...");
            Console.WriteLine("----------------------------\n");
            Console.ReadLine();
        }
        public static void DisplayDaysWeather(Day day)//Randomly chooses weather and outputs the current status of the day.
        {
            day = new Day();
            day.WeatherChooser();
            UserInterface.PressEnterToContinue();
        }
        public static void GameMenu(Player player, Day day, Store store, SimulateProgram simulateProgram)
        {
            Console.Clear();
            Console.WriteLine("\nHello " + player.name + " and welcome to your game menu." +
                              "You can see updated information such as weather and " +
                              "store costs. Use the number commands shown below or you" +
                              " can type the command to do any of the activities.\n");
            UserInterface.DisplayCurrentInventoryAndMoney(player);
            UserInterface.DisplayDaysWeather(day);
            UserInterface.DisplayStorePriceList(store);
            Console.WriteLine("(1) Show Rules" +
                              "(2) Go to Store" +
                              "(3) Start your Day" +
                              "(4) Skip Today" +
                              "(5) Exit Game\n");
            string userInputForMenu = Console.ReadLine().ToLower();
            switch (userInputForMenu)
            {
                case "1":
                case "show rules":
                case "rules":
                    Console.Clear();
                    UserInterface.DisplayRules();
                    UserInterface.PressEnterToContinue();
                    UserInterface.GameMenu(player, day, store, simulateProgram);
                    break;
                case "2":
                case "go to store":
                case "store":
                    Console.WriteLine("Heading to the store...");
                    UserInterface.PressEnterToContinue();
                    simulateProgram.StoreVisit();
                    break;
                case "3":
                case "start your day":
                case "day":
                    Console.WriteLine("Starting the Day...");
                    UserInterface.PressEnterToContinue();
                    break;
                case "4":
                case "skip today":
                case "skip":
                    Console.WriteLine("Skipping Day...");
                    simulateProgram.inGameDays++;
                    UserInterface.PressEnterToContinue();
                    break;
                case "5":
                case "exit game":
                case "exit":
                    Console.WriteLine("Exiting Game...");
                    Console.Clear();
                    System.Environment.Exit(0);
                    UserInterface.PressEnterToContinue();
                    break;
                default:
                    Console.WriteLine("That was not proper input");
                    UserInterface.PressEnterToContinue();
                    UserInterface.GameMenu(player, day, store, simulateProgram);
                    break;
            }
        }


    }
}
