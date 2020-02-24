using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    public class SimulateProgram
    {
        //Methods(HAS A)
        Random random = new Random();
        Store store = new Store();
        List<Customer> customers;
        List<Day> days;
        Player player;
        Pitcher pitcher;
        private double profitMade = 0;
        private double dailyProfitMade = 0;
        private double lemonadePrice = 0;
        private bool recipeCreated = false;
        private int whatDayIsIt = 1;





        //Constructor(IS A)
        public SimulateProgram()
        {

        }
        //Methods(CAN DO)
        public void GameMenu()//Needs to have option 4 updated to start the actual sale day
        {
            UserInterface.GameMenuText(player, days[whatDayIsIt - 1]);
            string userInputForMenu = Console.ReadLine().ToLower();
            switch (userInputForMenu)
            {
                case "1":
                case "show rules":
                case "rules":
                    Console.Clear();
                    UserInterface.DisplayRules();
                    UserInterface.PressEnterToContinue();
                    GameMenu();
                    break;
                case "2":
                case "create recipe":
                case "recipe":
                    Console.Clear();
                    Console.WriteLine("Going to create a recipe for the day...");
                    recipeCreated = true;
                    UserInterface.PressEnterToContinue();
                    RecipeCreation();
                    GameMenu();
                    break;
                case "3":
                case "go to store":
                case "store":
                    Console.WriteLine("Heading to the store...");
                    UserInterface.PressEnterToContinue();
                    store.StoreVisit(player);
                    GameMenu();
                    break;
                case "4":
                case "start your day":
                case "day":
                    WasARecipeCreated();
                    break;
                case "5":
                case "skip today":
                case "skip":
                    Console.WriteLine("Skipping Day...");
                    UserInterface.PressEnterToContinue();
                    break;
                case "6":
                case "exit game":
                case "exit":
                    Console.WriteLine("Exiting Game...");
                    UserInterface.PressEnterToContinue();
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("That was not proper input");
                    UserInterface.PressEnterToContinue();
                    GameMenu();
                    break;
            }
        }
        public void HowManyPlayers()//Asks the user how many players they want to have
        {
            UserInterface.HowManyPlayersText();
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    player = new Player();
                    Console.WriteLine("\nWelcome " + player.name + ", to the Lemonade Stand Game!");
                    UserInterface.PressEnterToContinue();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That was not a valid response, please press enter try again.");
                    UserInterface.PressEnterToContinue();
                    HowManyPlayers();
                    break;
            }
        }
        public void HowManyDaysToPlay()
        {
            days = new List<Day>();
            int howManyDaysChosen = UserInterface.HowManyDaysUserValidation();
            for (int i = 0; i < howManyDaysChosen; i++)
            {
                Day day = new Day(random);
                days.Add(day);
            }
            Console.WriteLine("Number of Days you will play is: " + days.Count);
        }
        private void BeginGame()//Only runs the beginning methods for setup only.
        {
            UserInterface.WelcomeToGame();
            UserInterface.DisplayRules();
            HowManyPlayers();
            HowManyDaysToPlay();
        }
        private void RecipeCreation()
        {
            pitcher = new Pitcher(player);
            UserInterface.DisplayCurrentInventoryAndMoney(player);
            SetLemonadePrice();
        }
        private void SetLemonadePrice() //Single responsability here. its only purpose is to set the price of lemonade for the day.
        {
            bool userInputIsAnDouble = false;
            while (!userInputIsAnDouble)
            {
                Console.WriteLine("Please set the price of your Lemonade for the day.");

                userInputIsAnDouble = Double.TryParse(Console.ReadLine(), out lemonadePrice);
            }
        }
        private void WasARecipeCreated() //Single responsability here. Its only purpose is to make sure the player had created a recipe for each day.
        {
            if (recipeCreated == false)
            {
                Console.WriteLine("You need to create a recipe first! Heading back to Game Menu...");
                UserInterface.PressEnterToContinue();
                GameMenu();
            }
            else
            {
                Console.WriteLine("Starting the Day...");
                UserInterface.PressEnterToContinue();
                SellingLemonade();
            }
        }
        private void CustomersForDayCreation()
        {
            customers = new List<Customer>();
            int customerCreationRandom = random.Next(1, 21);
            for (int i = 0; i < customerCreationRandom; i++)
            {
                Customer customer = new Customer(random);
                customers.Add(customer);
            }
        }
        private void CustomerPurchaseChanceModify(Customer customer)
        {
            if (days[whatDayIsIt - 1].condition == "Sunny")
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
            Console.WriteLine("Number of customers today is: " + customers.Count);
            foreach (Customer customer in customers)
            {
                CustomerPurchaseChanceModify(customer);
                ThatsToMuchMan(customer);
                if (pitcher.cupsRemaining >= 1)
                {
                    if (customer.chanceToBuy >= 40)
                    {
                        if (player.inventory.cups.Count >= 1)
                        {
                            Console.WriteLine("Ill take a cup of lemonade.");
                            pitcher.cupsRemaining -= 1;
                            player.inventory.cups.RemoveAt(0);
                            player.wallet.money += lemonadePrice;
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
            Console.ReadLine();
        }
        private void ThatsToMuchMan(Customer customer)
        {
            if (lemonadePrice >= 3.01)
            {
                customer.chanceToBuy = 0;
            }
        }
        private void MidGame()//Has the methods for the core of the game
        {
            foreach (Day day in days)
            {
                CustomersForDayCreation();
                GameMenu();


                DailyProfitMade();
                dailyProfitMade = 0;
                lemonadePrice = 0;
                recipeCreated = false;
                whatDayIsIt++;
                UserInterface.PressEnterToContinue();
            }
            Console.WriteLine("You've completed the game!");
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
    }
}
