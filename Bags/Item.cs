using System;

namespace Bags
{
    public class Item
    {
        private string _name;


        public Item(string name = "item")
        {
            _name = name;
        }
    }
    
    public class Cloth : Item
    {
        public Cloth(string name = "cloth") : base(name){}
    }
    
    public class Herb : Item
    {
        public Herb(string name = "herb") : base(name){}
    }
    
    public class Metal : Item
    {
        public Metal(string name = "herb") : base(name){}
    }
    
    public class Weapon : Item
    {
        public Weapon(string name = "herb") : base(name){}
    }
}