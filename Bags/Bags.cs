using System.Collections.Generic;
using System.Linq;

namespace Bags
{
    public class Bags
    {
        public List<string> BackPack { get; set; } = new ();
        public List<string> ExtraBag1 { get; set; } = new ();
        public List<string> ExtraBag2 { get; set; } = new ();
        public List<string> BagMetals { get; set; } = new ();
        public List<string> BagWeapons { get; set; } = new ();

        public Bags Add(string item)
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
        
        public Bags Add(IEnumerable<string> items)
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
                .OrderBy(i => i)
                .ToList();
            
            BackPack = new List<string>();
            ExtraBag1 = new List<string>();
            ExtraBag2 = new List<string>();
            BagMetals = new List<string>();
            BagWeapons = new List<string>();
            
            foreach (var item in allItems)
            {
                if (Items.MetalItems.Contains(item) && BagMetals.Count < 4) BagMetals.Add(item);
                else
                if (Items.WeaponItems.Contains(item) && BagWeapons.Count < 4) BagWeapons.Add(item);
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