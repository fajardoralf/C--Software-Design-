using System;
using System.Threading;


namespace BazaarOfTheBizarre
{
    class Program
    {
        private static readonly object syncLock = new object();
        private static readonly Random random = new Random();
        static void Main(string[] args)
        {
            //Items to be sold, change value here
            int items = 25;

            Bazaar[] bazaars = { new Bazaar("Per's Bazaar"), new Bazaar("Tomas's Bazaar") };

            /*If you want to change the amount of customer you can do it here. Put "new Customer("name") after Ali"
            Remember to put in a new thread in the foreach loop, if you put in a new customer
             */
            Customer[] customers = { new Customer("Abdul"), new Customer("Salem"), new Customer("Ali") };
            

            Thread i1 = new Thread(() => bazaars[0].MakeItem(items));
            Thread i2 = new Thread(() => bazaars[1].MakeItem(items));
            
            i1.Start();
            i2.Start();


            int number = random.Next(0, 3);
            foreach (Bazaar i in bazaars)
            {
                lock (syncLock)
                {
                    Thread customer1 = new Thread(() => i.SellItemTo(customers[0]));
                    Thread customer2 = new Thread(() => i.SellItemTo(customers[1]));
                    Thread customer3 = new Thread(() => i.SellItemTo(customers[2]));
                    
                    customer1.Start();
                    customer2.Start();
                    customer3.Start();
                }
                
            }
        }
    }
}