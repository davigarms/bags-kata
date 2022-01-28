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

        private static readonly List<Item> AllItems = new ();

        static Items()
        {
            var jObject = JObject.Parse(ItemsData);
            
            var clothItems = jObject["clothes"].ToObject<List<string>>().ToList();
            var herbItems = jObject["herbs"].ToObject<List<string>>().ToList();
            var metalItems = jObject["metals"].ToObject<List<string>>().ToList();
            var weaponItems = jObject["weapons"].ToObject<List<string>>().ToList();

            clothItems.ForEach(i => AllItems.Add(new Cloth(i)));
            herbItems.ForEach(i => AllItems.Add(new Herb(i)));
            metalItems.ForEach(i => AllItems.Add(new Metal(i)));
            weaponItems.ForEach(i => AllItems.Add(new Weapon(i)));
        }
        
        public static List<Item> SpawnItems(int numberOfItems = 1)
        {
            var spawnedItems = new List<Item>();

            for (var i = 0; i < numberOfItems; i++)
            {
                var index = new Random().Next(0, AllItems.Count);
                spawnedItems.Add(new Item());
            }
               
            
            return spawnedItems;
        }
    }
}