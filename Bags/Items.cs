using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Bags
{
    public static class Items
    {
        private const string ItemsData = @"{
            'clothes': ['Leather', 'Linen', 'Silk', 'Wool'],
            'herbs': ['Cherry Blossom', 'Marigold', 'Rose', 'Seaweed'],
            'metals': ['Copper', 'Gold', 'Iron', 'Silver'],
            'weapons': ['Axe', 'Dagger', 'Mace', 'Sword']
        }";
        
        public static List<string> ClothItems {get; }
        public static List<string> HerbItems {get; }
        public static List<string> MetalItems {get; }
        public static List<string> WeaponItems {get; }

        static Items()
        {
            var jObject = JObject.Parse(ItemsData);
            
            ClothItems = jObject["clothes"].ToObject<List<string>>();
            HerbItems = jObject["herbs"].ToObject<List<string>>();
            MetalItems = jObject["metals"].ToObject<List<string>>();
            WeaponItems = jObject["weapons"].ToObject<List<string>>();
        }
        
        public static List<string> SpawnItems(int numberOfItems = 1)
        {
            var spawnedItems = new List<string>();
            
            for (var i = 0; i < numberOfItems; i++)
                spawnedItems.Add("item");
            
            return spawnedItems;
        }
    }
}