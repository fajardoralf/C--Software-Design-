using System;


namespace BazaarOfTheBizarre
{
    public class ItemFactory
    {
        Random random = new Random();

        public Item produceItems(int id)
        {
            int choice = random.Next(3);
            if(choice == 0)
            {
                return new Sword(id);
            }
            else if(choice == 2)
            {
                return new Runestone(id);
            }
            else
            {
                return new Ring(id);
            }
        }
    }
}
