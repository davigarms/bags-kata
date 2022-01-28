using System;
using System.Collections.Generic;

namespace Bags
{
   public class Bags
    {
        public List<Item> BackPack { get; init; } = new ();
        public List<Item> ExtraBag1 { get; init; } = new ();
        public List<Item> ExtraBag2 { get; init; } = new ();
        public List<Item> ExtraBag3 { get; init; } = new ();
        public List<Item> ExtraBag4 { get; init; } = new ();

        public Bags Add(Item item)
        {
            if (BackPack.Count < 8) BackPack.Add(item);
            else 
            if (ExtraBag1.Count < 4) ExtraBag1.Add(item);
            else 
            if (ExtraBag2.Count < 4) ExtraBag2.Add(item);
            else 
            if (ExtraBag3.Count < 4) ExtraBag3.Add(item);
            else 
            if (ExtraBag4.Count < 4) ExtraBag4.Add(item);
            
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
                if (ExtraBag3.Count < 4) ExtraBag3.Add(item);
                else 
                if (ExtraBag4.Count < 4) ExtraBag4.Add(item);
            }
            
            return this;
        }
    }
}