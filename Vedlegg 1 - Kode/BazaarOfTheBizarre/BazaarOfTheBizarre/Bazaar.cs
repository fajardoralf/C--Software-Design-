using System;
using System.Collections.Generic;
using System.Threading;

namespace BazaarOfTheBizarre
{
    public class Bazaar
    {
        private string _name;

        public string Name { get { return _name; } set { _name = value; } }
        private ItemFactory itemFactory = new ItemFactory();
        public Queue<Item> itemBasket1 = new Queue<Item>();
        public Queue<Item> itemBasket2 = new Queue<Item>();
        public Queue<Item> itemBasket3 = new Queue<Item>();
        private readonly Object thisLock = new Object();
        Random random = new Random();
        public Bazaar(string name)
        {
            Name = name;
        }

        public void MakeItem(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                Item item1 = itemFactory.produceItems(i);
                Item item2 = itemFactory.produceItems(i + 1);
                Item item3 = itemFactory.produceItems(i + 2);
                itemBasket1.Enqueue(item1);
                itemBasket2.Enqueue(item2);
                itemBasket3.Enqueue(item3);
                Console.WriteLine("{0} made Item #{1} up for sale", this._name, i+1);
                
                Thread.Sleep(1000);
            }
        }

        public void SellItemTo(Customer customer)
        {
            do
            {
                lock (thisLock)
                {
                    Thread.Sleep(790);
                    if (itemBasket1.Count > 0)
                    {
                        Item item1 = itemBasket1.Dequeue();
                        Item item2 = itemBasket2.Dequeue();
                        Item item3 = itemBasket3.Dequeue();
                        int choice = random.Next(3);
                        if (choice == 0)
                        {
                            Console.WriteLine("\t\t\t\t\t{0} bought {1} item #{2} {3}", customer.Name, this._name, item1.Id + 1, item1.Name);
                        }
                        else if (choice == 1)
                        {
                            Console.WriteLine("\t\t\t\t\t{0} bought {1} item #{2} {3} and {4}", customer.Name, this._name, item1.Id + 1, item1.Name, item2.Name);
                        }
                        else
                        {
                            Console.WriteLine("\t\t\t\t\t{0} bought {1} item #{2} {3} and {4} and {5}", customer.Name, this._name, item1.Id + 1, item1.Name, item2.Name, item3.Name);
                        }
                    }
                }
            } while (true);
        }
    }
}
