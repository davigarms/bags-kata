using System;

namespace Bags
{
    public class Item
    {
        public string Name { get; }
        
        public string Type { get; }

        public Item(string name = "item", string type = "item")
        {
            Name = name;
            Type = type;
        }
    }
    
    public class Cloth : Item
    {
        public Cloth(string name = "item", string type = "cloth") : base(name, type){}
    }
    
    public class Herb : Item
    {
        public Herb(string name = "item", string type = "herb") : base(name, type){}
    }
    
    public class Metal : Item
    {
        public Metal(string name = "item", string type = "metal") : base(name, type){}
    }
    
    public class Weapon : Item
    {
        public Weapon(string name = "item", string type = "weapon") : base(name, type){}
    }
}