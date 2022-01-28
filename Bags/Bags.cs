using System.Collections.Generic;

namespace Bags
{
    public class Bags
    {
        public List<string> BackPack { get; init; } = new ();
        public List<string> ExtraBag1 { get; init; } = new ();
        public List<string> ExtraBag2 { get; init; } = new ();
        public List<string> ExtraBag3 { get; init; } = new ();
        public List<string> ExtraBag4 { get; init; } = new ();

        public Bags Add(string item)
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
                if (ExtraBag3.Count < 4) ExtraBag3.Add(item);
                else 
                if (ExtraBag4.Count < 4) ExtraBag4.Add(item);
            }
            
            return this;
        }
    }
}