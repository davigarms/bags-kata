using System.Linq;
using System.Collections.Generic;

namespace Bags
{
   public class Bags
    {
        public List<Item> BackPack { get; set; } = new ();
        public List<Item> ExtraBag1 { get; set; } = new ();
        public List<Item> ExtraBag2 { get; set; } = new ();
        public List<Item> BagMetals { get; set; } = new ();
        public List<Item> BagWeapons { get; set; } = new ();

        public Bags Add(Item item)
        {
            if (BackPack.Count < 8) BackPack.Add(item);
            else 
            if (ExtraBag1.Count < 4) ExtraBag1.Add(item);
            else 
            if (ExtraBag2.Count < 4) ExtraBag2.Add(item);
            else 
            if (BagMetals.Count < 4) BagMetals.Add(item);
            else 
            if (BagWeapons.Count < 4) BagWeapons.Add(item);
            
            return this;
        }
        
        public Bags Add(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                if (BackPack.Count < 8) BackPack.Add(item);
                else 
                if (ExtraBag1.Count < 4) ExtraBag1.Add(item);
                else 
                if (ExtraBag2.Count < 4) ExtraBag2.Add(item);
                else 
                if (BagMetals.Count < 4) BagMetals.Add(item);
                else 
                if (BagWeapons.Count < 4) BagWeapons.Add(item);
            }
            
            return this;
        }
        
        public void CastOrganisingSpell()
        {
            var allItems = BackPack
                .Concat(ExtraBag1)
                .Concat(ExtraBag2)
                .Concat(BagMetals)
                .Concat(BagWeapons)
                .OrderBy(i => i.Name)
                .ToList();
            
            BackPack = new List<Item>();
            ExtraBag1 = new List<Item>();
            ExtraBag2 = new List<Item>();
            BagMetals = new List<Item>();
            BagWeapons = new List<Item>();
            
            foreach (var item in allItems)
            {
                if (item.GetType() == typeof(Metal) && BagMetals.Count < 4) BagMetals.Add(item);
                else
                if (item.GetType() == typeof(Weapon) && BagWeapons.Count < 4) BagWeapons.Add(item);
                else
                if (BackPack.Count < 8) BackPack.Add(item);
                else
                if (ExtraBag1.Count < 4) ExtraBag1.Add(item);
                else
                if (ExtraBag2.Count < 4) ExtraBag2.Add(item);
            };
        }
    }
}