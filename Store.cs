using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Store
    {
        // member variables (HAS A)
        public double pricePerLemon;
        public double pricePerSugarCube;
        public double pricePerIceCube;
        public double pricePerCup;
        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .50;
            pricePerSugarCube = .10;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }
        // member methods (CAN DO)
        public void StoreVisit(Player player)
        {
            Console.WriteLine("Welcome to my general store what would you like to buy?");
            PurchasingProducts(player);
        }
        private void PurchasingProducts(Player player)
        {
            Console.WriteLine("\n(please type in the name of the product from the list, if nothing or done type Exit)");
            UserInterface.DisplayStorePriceList(this);
            string input = Console.ReadLine().ToUpper();
            switch (input)
            {
                case "LEMONS":
                    SellLemons(player);
                    Console.WriteLine("\n");
                    Console.WriteLine("Here is your updated inventory and wallet " + player.name + ": ");
                    UserInterface.DisplayCurrentInventoryAndMoney(player);
                    Console.Clear();
                    PurchasingProducts(player);
                    break;
                case "SUGAR CUBES":
                    SellSugarCubes(player);
                    Console.WriteLine("\n");
                    Console.WriteLine("Here is your updated inventory and wallet " + player.name + ": ");
                    UserInterface.DisplayCurrentInventoryAndMoney(player);
                    Console.Clear();
                    PurchasingProducts(player);
                    break;
                case "ICE CUBES":
                    SellIceCubes(player);
                    Console.WriteLine("\n");
                    Console.WriteLine("Here is your updated inventory and wallet " + player.name + ": ");
                    UserInterface.DisplayCurrentInventoryAndMoney(player);
                    Console.Clear();
                    PurchasingProducts(player);
                    break;
                case "CUPS":
                    SellCups(player);
                    Console.WriteLine("\n");
                    Console.WriteLine("Here is your updated inventory and wallet " + player.name + ": ");
                    UserInterface.DisplayCurrentInventoryAndMoney(player);
                    Console.Clear();
                    PurchasingProducts(player);
                    break;
                case "EXIT":
                    Console.WriteLine("\nThankyou for coming see you again soon!");
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That was invalid user input please try again...");
                    PurchasingProducts(player);
                    break;
            }
        }
        public void SellLemons(Player player)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if (player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddLemonsToInventory(lemonsToPurchase);
            }
        }
        public void SellSugarCubes(Player player)
        {
            int sugarToPurchase = UserInterface.GetNumberOfItems("sugar");
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            if (player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddSugarCubesToInventory(sugarToPurchase);
            }
        }
        public void SellIceCubes(Player player)
        {
            int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            if (player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddIceCubesToInventory(iceCubesToPurchase);
            }
        }
        public void SellCups(Player player)
        {
            int cupsToPurchase = UserInterface.GetNumberOfItems("cups");
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            if (player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddCupsToInventory(cupsToPurchase);
            }
        }
        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }
        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }
    }
}
