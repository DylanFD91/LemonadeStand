using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        // member variables (HAS A)
        public double moneyInWallet;
        public int chanceToBuy;
        Random random = new Random();
        // constructor (SPAWNER)
        public Customer()
        {
            ChanceToBuy();
        }

        // member methods (CAN DO)
        
        /*public void MoneyInWallet()
        {
            moneyInWallet = random.Next(1, 5);
        }*/
        public void ChanceToBuy()
        {
            chanceToBuy = random.Next(40, 60);
        }
    }
}
