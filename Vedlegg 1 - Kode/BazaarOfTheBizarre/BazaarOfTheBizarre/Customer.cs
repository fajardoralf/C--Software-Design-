using System;


namespace BazaarOfTheBizarre
{
    public class Customer
    {
        private string _name;

        public string Name { get { return _name; } set { _name = value; } }

        public Customer(String name)
        {
            Name = name;
        }
    }
}
