using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class SimulateProgram
    {
        //Methods(HAS A)
        Player player1;
        Day day;
        Pitcher pitcher;
        Customer customer;
        Store store = new Store();
        List<Customer> customers;
        public double profitMade = 0;
        public double dailyProfitMade = 0;
        public double lemonadePrice = 0;
        public int inGameDays = 1;

        //Constructor(IS A)
        public SimulateProgram()
        {

        }

        //Methods(CAN DO)
        private void BeginGame()//Only runs the beginning methods
        {
            UserInterface.WelcomeToGame();
            UserInterface.DisplayRules();
            HowManyPlayers();

            //UserInterface.GameMenu(player1, day, store);


            Console.WriteLine("Here is your current inventory and starting cash " + player1.name + ": ");
            UserInterface.DisplayCurrentInventoryAndMoney(player1);
            Console.WriteLine("\nSince your inventory is empty lets head to the store...");
            Console.ReadLine();
            Console.Clear();
        }
        private void HowManyPlayers()//Asks the user how many players they want to have
        {
            Console.WriteLine("One or Two Players? The second player will be an AI...(Please Type 1 or 2)");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    player1 = new Player();
                    Console.WriteLine("\nWelcome " + player1.name + "! Press Enter to Continue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That was not a valid response, please press enter try again.");
                    Console.ReadLine();
                    HowManyPlayers();
                    break;
            }
            Console.Clear();
        }
        
        private void MidGame()//Has the methods for the core of the game
        {
            if (inGameDays != 7)
            {
                UserInterface.DisplayDaysWeather(day);
                StoreVisit();
                RecipeCreation();
                CustomersForDayCreation();

                SellingLemonade();

                inGameDays++;
                DailyProfitMade();
                Console.ReadLine();
                dailyProfitMade = 0;
                lemonadePrice = 0;
                Console.Clear();
                MidGame();
            }
            else
            {
                Console.WriteLine("You've completed the Week!");
            }
        }

        public void StoreVisit()
        {
            Console.WriteLine("Welcome to my general store what would you like to buy?");
            PurchasingProducts();
        }
        private void PurchasingProducts()
        {
            Console.WriteLine("\n(please type in the name of the product from the list, if nothing or done type Exit)");
            UserInterface.DisplayStorePriceList(store);
            string input = Console.ReadLine().ToUpper();
            switch (input)
            {
                case "LEMONS":
                    store.SellLemons(player1);
                    Console.WriteLine("\n");
                    Console.WriteLine("Here is your updated inventory and wallet " + player1.name + ": ");
                    UserInterface.DisplayCurrentInventoryAndMoney(player1);
                    Console.Clear();
                    PurchasingProducts();
                    break;
                case "SUGAR CUBES":
                    store.SellSugarCubes(player1);
                    Console.WriteLine("\n");
                    Console.WriteLine("Here is your updated inventory and wallet " + player1.name + ": ");
                    UserInterface.DisplayCurrentInventoryAndMoney(player1);
                    Console.Clear();
                    PurchasingProducts();
                    break;
                case "ICE CUBES":
                    store.SellIceCubes(player1);
                    Console.WriteLine("\n");
                    Console.WriteLine("Here is your updated inventory and wallet " + player1.name + ": ");
                    UserInterface.DisplayCurrentInventoryAndMoney(player1);
                    Console.Clear();
                    PurchasingProducts();
                    break;
                case "CUPS":
                    store.SellCups(player1);
                    Console.WriteLine("\n");
                    Console.WriteLine("Here is your updated inventory and wallet " + player1.name + ": ");
                    UserInterface.DisplayCurrentInventoryAndMoney(player1);
                    Console.Clear();
                    PurchasingProducts();
                    break;
                case "EXIT":
                    Console.WriteLine("\nThankyou for coming see you again soon!");
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That was invalid user input please try again...");
                    PurchasingProducts();
                    break;
            }
        }
        
        private void RecipeCreation()
        {
            pitcher = new Pitcher(player1);
            UserInterface.DisplayCurrentInventoryAndMoney(player1);
            SetLemonadePrice();
        }
        private void SetLemonadePrice()
        {
            bool userInputIsAnDouble = false;
            while (!userInputIsAnDouble)
            {
                Console.WriteLine("Please set the price of your Lemonade for the day.");

                userInputIsAnDouble = Double.TryParse(Console.ReadLine(), out lemonadePrice);
            }
        }

        private void CustomersForDayCreation()
        {
            customers = new List<Customer>();
            int customerCreationRandom = new Random().Next(1, 21);
            for (int i = 0; i < customerCreationRandom; i++)
            {
                customer = new Customer();
                customers.Add(customer);
            }
            CustomerPurchaseChanceModify();
            Console.WriteLine("Number of customers today is: " + customers.Count);
        }
        private void CustomerPurchaseChanceModify()
        {
            if (day.condition == "Sunny")
            {
                customer.chanceToBuy += 30;
            }
            else
            {
                customer.chanceToBuy -= 10;
            }
        }

        private void SellingLemonade()
        {
            Console.WriteLine("Lets start our day!");
            foreach (Customer customer in customers)
            {
                if(pitcher.cupsRemaining >= 1)
                {
                    if (customer.chanceToBuy >= 40)
                    {
                        if (player1.inventory.cups.Count >= 1)
                        {
                            Console.WriteLine("Ill take a cup of lemonade.");
                            pitcher.cupsRemaining -= 1;
                            player1.inventory.cups.RemoveAt(0);
                            player1.wallet.money += lemonadePrice;
                            dailyProfitMade += lemonadePrice;
                            profitMade += lemonadePrice;
                        }
                        else
                        {
                            Console.WriteLine("you have run out of cups");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No thankyou I dont want any lemonade.");
                    }
                }
                else
                {
                    Console.WriteLine("your pitcher is empty");
                }
            }
        }
        private void DailyProfitMade()
        {
            Console.WriteLine("You made " + dailyProfitMade + " today, good job!");
            UserInterface.DisplayCurrentInventoryAndMoney(player1);
        }

        public void EndGame()//Wraps the game up and displays what the player made
        {
            Console.WriteLine("You've reached the end this is how much you made entirely: " + profitMade);
            Console.ReadLine();
        }
        public void RunGame()//Runs the begin/mid/end game methods
        {
            BeginGame();
            MidGame();
            EndGame();
        }
        private void PlayAgain()//Play again?
        {

        }
    }
}
