﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BazaarOfTheBizarre
{
   public abstract class Item
    {
        private string _name;

        public string Name { get { return _name; } set { _name = value; } }

        public int Id { get; set; }
    }
}
