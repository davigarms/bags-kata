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

        private static readonly List<string> AllItems;

        static Items()
        {
            var jObject = JObject.Parse(ItemsData);
            
            var clothItems = jObject["clothes"].ToObject<List<string>>().ToList();
            var herbItems = jObject["herbs"].ToObject<List<string>>().ToList();
            var metalItems = jObject["metals"].ToObject<List<string>>().ToList();
            var weaponItems = jObject["weapons"].ToObject<List<string>>().ToList();

            AllItems = clothItems
                .Concat(herbItems)
                .Concat(metalItems)
                .Concat(weaponItems)
                .ToList();
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