using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        public string name;

        // constructor (SPAWNER)
        public Player()
        {
            EnterName();
            inventory = new Inventory();
            wallet = new Wallet();
        }

        // member methods (CAN DO)
        public void EnterName()
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Please enter your name: ");
            Console.WriteLine("-----------------------\n");
            string input = Console.ReadLine();
            name = input;
        }
        public void CreateRecipe()
        {

        }
    }
}
