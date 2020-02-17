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
            Console.WriteLine("Wallet: $" + player.wallet.Money);
            Console.WriteLine("Inventory: ");
            Console.WriteLine("Lemons: " + player.inventory.lemons.Count);
            Console.WriteLine("Sugar Cubes: " + player.inventory.sugarCubes.Count);
            Console.WriteLine("Ice Cubes: " + player.inventory.iceCubes.Count);
            Console.WriteLine("Cups: " + player.inventory.cups.Count);
            Console.ReadLine();
        }


    }
}
