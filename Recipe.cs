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
        private string recipeType;
        public int lemonsUsed;
        public int sugarCubesUsed;
        public int iceCubesUsed;

        // constructor (SPAWNER)
        public Recipe()
        {
            CreateRecipe();
            recipeType = "";
            CreatePitcher();
        }

        // member methods (CAN DO)
        public void CreateRecipe()
        {
            Console.WriteLine("Lets create a pitcher. How many Lemons would you like to use?");
            LemonsForRecipe();

            Console.WriteLine("How many Sugar Cubes would you like to use?");
            SugarForRecipe();

            Console.WriteLine("How many Ice Cubes would you like to use?");
            IceForRecipe();
        }
        public void LemonsForRecipe()
        {
            string lemonInput = Console.ReadLine();
            try
            {
                lemonsUsed = Int32.Parse(lemonInput);
                Console.WriteLine(lemonsUsed + " will be used for this recipe");
            }
            catch(FormatException)
            {
                Console.WriteLine($"'{lemonInput}' was not a valid amount. Please press Enter and try again...");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("How many Lemons would you like to use?");
                LemonsForRecipe();
            }
        }
        public void SugarForRecipe()
        {
            string sugarInput = Console.ReadLine();
            try
            {
                sugarCubesUsed = Int32.Parse(sugarInput);
                Console.WriteLine(sugarCubesUsed + " will be used for this recipe");
            }
            catch(FormatException)
            {
                Console.WriteLine($"'{sugarInput}' was not a valid amount. Please press Enter and try again...");
                Console.ReadLine();
                Console.ReadLine();
                Console.WriteLine("How many Sugar Cubes would you like to use?");
                SugarForRecipe();
            }
        }
        public void IceForRecipe()
        {
            string iceInput = Console.ReadLine();
            try
            {
                iceCubesUsed = Int32.Parse(iceInput);
                Console.WriteLine(iceCubesUsed + " will be used for this recipe");
            }
            catch(FormatException)
            {
                Console.WriteLine($"'{iceInput}' was not a valid amount. Please press Enter and try again...");
                Console.ReadLine();
                Console.ReadLine();
                Console.WriteLine("How many Ice Cubes would you like to use?");
                IceForRecipe();
            }
        }
        public void DetermineRecipeType()
        {
            if (lemonsUsed >= 4 && lemonsUsed <= 7)//for standard pitcher
            {
                if (sugarCubesUsed >= 7 && sugarCubesUsed <= 10)//for standard pitcher
                {
                    recipeType = "Standard Pitcher";
                }
                else if (sugarCubesUsed >= 11)
                {
                    recipeType = "Sweet Pitcher";
                }
                else if (sugarCubesUsed <= 6)
                {
                    recipeType = "Sour Pitcher";
                }
            }
            else if (lemonsUsed >= 8)
            {

            }
            else if (lemonsUsed <=3)
            {

            }
        }
        public Pitcher CreatePitcher()
        {
            return null;
        }
    }
}
