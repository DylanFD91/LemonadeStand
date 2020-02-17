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
        //Player player2; (doing later)
        Store store = new Store();
        Day day;
        Pitcher pitcher;
        Customer customer;
        List<Customer> customers;
        public int profitMade = 0;

        //Constructor(IS A)
        public SimulateProgram()
        {

        }
        //Methods(CAN DO)

        //Frequent used Methods
        private void StorePricesList()
        {
            Console.WriteLine("\nHere is a list of my goods and there current prices:");
            Console.WriteLine("Lemons: $" + store.pricePerLemon);
            Console.WriteLine("Sugar Cubes: $" + store.pricePerSugarCube);
            Console.WriteLine("Ice Cubes: $" + store.pricePerIceCube);
            Console.WriteLine("Cups: $" + store.pricePerCup + "\n");
        }



        private void BeginGame()//Only runs the beginning methods
        {
            WelcomeToGame();
            DisplayRules();
            HowManyPlayers();
            Console.WriteLine("Here is your current inventory and starting cash " + player1.name + ": ");
            UserInterface.DisplayCurrentInventoryAndMoney(player1);
            Console.WriteLine("\nSince your inventory is empty lets head to the store...");
            Console.ReadLine();
            Console.Clear();
        }
        private void WelcomeToGame()//Welcomes player to the game with a brief layout of game
        {
            Console.WriteLine("Welcome to your lemonade stand.");
            Console.ReadLine();
        }
        private void DisplayRules()//Displays some rules to the game and objective
        {
            Console.WriteLine("you run a lemonade stand and you can buy supplies from a local store, try to sell as much as you can in seven days.");
            Console.ReadLine();
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
                case "2":
                    player1 = new Player();
                    //player2 = new AI();
                    //Console.WriteLine("\nWelcome " + player1.name + " and " + player2.name + "! Press Enter to Continue...");
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
            int inGameDays = 7;
            do
            {
                DisplayTheDaysWeather();
                StoreVisit();
                RecipeCreation();
                CustomersForDayCreation();



                DailyProfitMade();
            } while (inGameDays >= 0);
        }

        private void DisplayTheDaysWeather()
        {
            day = new Day();
            day.WeatherChooser();
            Console.ReadLine();
        }

        private void StoreVisit()
        {
            Console.WriteLine("Welcome to my general store what would you like to buy?");
            PurchasingProducts();
        }
        private void PurchasingProducts()
        {
            Console.WriteLine("\n(please type in the name of the product from the list, if nothing or done type Exit)");
            StorePricesList();
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
        }

        private void CustomersForDayCreation()
        {
            customers = new List<Customer>();
            int howManyCustomersToday = new Random().Next(1, 21);
            for (int i = 0; i < howManyCustomersToday; i++)
            {
                customer = new Customer();
                customers.Add(customer);
            }
        }

        private void DailyProfitMade()
        {

        }

        private void EndGame()//Wraps the game up and displays what the player made
        {

        }
        public void RunGame()//Runs the begin/mid/end game methods
        {
            BeginGame();
            MidGame();
            //EndGame();
        }
        private void PlayAgain()//Play again?
        {

        }
    }
}
