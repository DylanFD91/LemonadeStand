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
            Console.WriteLine("-----------------------");
            Console.WriteLine("Wallet: $" + player.wallet.Money + "\n");
            Console.WriteLine("Inventory: ");
            Console.WriteLine("Lemons: " + player.inventory.lemons.Count);
            Console.WriteLine("Sugar Cubes: " + player.inventory.sugarCubes.Count);
            Console.WriteLine("Ice Cubes: " + player.inventory.iceCubes.Count);
            Console.WriteLine("Cups: " + player.inventory.cups.Count);
            Console.WriteLine("-----------------------");
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
        public static void DisplayRules()//Displays the rules and can be called from game menu
        {
            Console.WriteLine("\nyou run a lemonade stand and you can buy supplies from a local store, try to sell as much as you can in seven days.\n");
        }
        public static void PressEnterToContinue()//A console clear and readline output
        {
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("Press (Enter) to continue...");
            Console.WriteLine("----------------------------\n");
            Console.ReadLine();
            Console.Clear();
        }
        public static void GameMenuText(Player player, Day days)//Text for the game menu method in simulate program
        {
            Console.Clear();
            Console.WriteLine("\nHello " + player.name + " and welcome to your game menu. Use the number\n" +
                              "commands shown below or you can type the command to do any of the activities\n");
            UserInterface.DisplayCurrentDay(days);
            UserInterface.DisplayCurrentInventoryAndMoney(player);
            Console.WriteLine("(1) Show Rules\n" +
                              "(2) Create Recipe\n" +
                              "(3) Go to Store\n" +
                              "(4) Start your Day\n" +
                              "(5) Skip Today\n" +
                              "(6) Exit Game\n");
        }
        public static void HowManyPlayersText()//Filler text for how many players
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("|       How Many Players?       |");
            Console.WriteLine("|Please Type 1 other options N/A|");
            Console.WriteLine("---------------------------------\n");
        }
        public static void HowManyDaysToPlayText()//Filler text for day amount method
        {
            Console.WriteLine("How many days would you like to play?");
        }
        public static int HowManyDaysUserValidation()//Verify user input for days wanting to play
        {
            bool isInputAnInt = false;
            int howManyDaysChosen = 0;
            while (!isInputAnInt)
            {
                Console.WriteLine("How many days would you like to play?");
                isInputAnInt = Int32.TryParse(Console.ReadLine(), out howManyDaysChosen);
            }
            return howManyDaysChosen;
        }
        public static void DisplayCurrentDay(Day day)//outputs the current status of the day.
        {
            Console.WriteLine("It's Day " + day.dayNumber + ", it's currently " + day.temperature + "F°, and " + day.condition + ".");
        }
    }
}
