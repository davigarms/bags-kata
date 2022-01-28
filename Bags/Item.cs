using System;

namespace Bags
{
    public class Item
    {
        public string Name { get; }
        
        public Item(string name = "item")
        {
            Name = name;
        }
    }
    
    public class Cloth : Item
    {
        public Cloth(string name = "Cloth") : base(name){}
    }
    
    public class Herb : Item
    {
        public Herb(string name = "Herb") : base(name){}
    }
    
    public class Metal : Item
    {
        public Metal(string name = "Metal") : base(name){}
    }
    
    public class Weapon : Item
    {
        public Weapon(string name = "Weapon") : base(name){}
    }
}