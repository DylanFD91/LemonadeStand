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
        public int chanceToBuy;
        Random random;


        // constructor (SPAWNER)
        public Customer(Random random)
        {
            this.random = random;
            ChanceToBuy();
        }

        public void ChanceToBuy()
        {
            chanceToBuy = random.Next(1, 101);
        }
    }
}
