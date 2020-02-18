using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Recipe
    {
        // member variables (HAS A)
        public int lemonsUsed;
        public int sugarCubesUsed;
        public int iceCubesUsed;

        // constructor (SPAWNER)
        public Recipe(Player player)
        {
            CreateRecipe(player);
        }

        // member methods (CAN DO)
        public void CreateRecipe(Player player)
        {
            Console.WriteLine("Lets create a pitcher. How many Lemons would you like to use?");
            LemonsForRecipe(player);

            Console.WriteLine("How many Sugar Cubes would you like to use?");
            SugarForRecipe(player);

            Console.WriteLine("How many Ice Cubes would you like to use?");
            IceForRecipe(player);
        }

        public void LemonsForRecipe(Player player)
        {
            string lemonInput = Console.ReadLine();
            try
            {
                lemonsUsed = Int32.Parse(lemonInput);
                if (lemonsUsed <= player.inventory.lemons.Count)
                {
                    Console.WriteLine(lemonsUsed + " will be used for this recipe");
                    LemonsUsedFromInventory(player);
                }
                else if (lemonsUsed == 0)
                {
                    Console.WriteLine("You need to use some ingredients please try again.");
                    LemonsForRecipe(player);
                }
                else
                {
                    Console.WriteLine(lemonsUsed + " is to many lemons compared to your inventory please try again.");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(player.inventory.lemons.Count + " is how many lemons are in your inventory currently.");
                    LemonsForRecipe(player);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine($"'{lemonInput}' was not a valid amount. Please press Enter and try again...");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("How many Lemons would you like to use?");
                LemonsForRecipe(player);
            }
        }
        public void LemonsUsedFromInventory(Player player)
        {
            for (int index = 0; index < lemonsUsed; lemonsUsed--)
            {
                player.inventory.lemons.RemoveAt(0);
            }
        }

        public void SugarForRecipe(Player player)
        {
            string sugarInput = Console.ReadLine();
            try
            {
                sugarCubesUsed = Int32.Parse(sugarInput);
                if (sugarCubesUsed <= player.inventory.sugarCubes.Count)
                {
                    Console.WriteLine(sugarCubesUsed + " will be used for this recipe");
                    SugarCubesUsedFromInventory(player);
                }
                else
                {
                    Console.WriteLine(sugarCubesUsed + " is to many cubes of sugar compared to your inventory please try again.");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(player.inventory.sugarCubes.Count + " is how many sugar cubes are in your inventory currently.");
                    SugarForRecipe(player);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine($"'{sugarInput}' was not a valid amount. Please press Enter and try again...");
                Console.ReadLine();
                Console.ReadLine();
                Console.WriteLine("How many Sugar Cubes would you like to use?");
                SugarForRecipe(player);
            }
        }
        public void SugarCubesUsedFromInventory(Player player)
        {
            for (int index = 0; index < sugarCubesUsed; sugarCubesUsed--)
            {
                player.inventory.sugarCubes.RemoveAt(0);
            }
        }

        public void IceForRecipe(Player player)
        {
            string iceInput = Console.ReadLine();
            try
            {
                iceCubesUsed = Int32.Parse(iceInput);
                if (iceCubesUsed <= player.inventory.iceCubes.Count)
                {
                    Console.WriteLine(iceCubesUsed + " will be used for this recipe");
                    IceCubesUsedFromInventory(player);
                }
                else
                {
                    Console.WriteLine(iceCubesUsed + " is to many cubes of ice compared to your inventory please try again.");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(player.inventory.iceCubes.Count + " is how many ice cubes are in your inventory currently.");
                    IceForRecipe(player);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine($"'{iceInput}' was not a valid amount. Please press Enter and try again...");
                Console.ReadLine();
                Console.ReadLine();
                Console.WriteLine("How many Ice Cubes would you like to use?");
                IceForRecipe(player);
            }
        }
        public void IceCubesUsedFromInventory(Player player)
        {
            for (int index = 0; index < iceCubesUsed; iceCubesUsed--)
            {
                player.inventory.iceCubes.RemoveAt(0);
            }
        }
    }
}
