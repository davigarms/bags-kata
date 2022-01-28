using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bags
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_add_an_item_in_the_backpack()
        {
            var bag = new Bags();
            var item = Items.SpawnItems();
            bag.Add(item[0]);
            Assert.That(bag.BackPack.Contains(item[0]));
        }
        
        [TestCase("item",  "item", "item, item")]
        [TestCase("item, item, item, item, item, item, item, item", "item", "item, item, item, item, item, item, item, item")]
        [TestCase("item, item, item, item, item, item, item", "item, item", "item, item, item, item, item, item, item, item")]
        public void Should_add_items_in_the_backpack_while_the_number_of_items_is_less_than_8(string initialItems, string addedItems, string expectedItems)
        {
            var initialList = initialItems.Split(", ").ToList();
            var addedList = addedItems.Split(", ").ToList();
            var backPack = expectedItems.Split(", ").ToList();
            
            var bag = new Bags();
            bag.Add(initialList);
            bag.Add(addedList);
            
            Assert.Multiple(() =>
            {
                Assert.That(bag.BackPack, Is.EqualTo(backPack));
                Assert.That(bag.BackPack.Count <= 8);
            });
        }
        
        
        [TestCaseSource(nameof(GreaterThan8DataSource))]
        public void Should_add_items_to_an_extra_bag_when_the_number_of_items_is_greater_than_8(List<string> initialList, List<string> addedList, Bags expectedBags)
        {
            var bag = new Bags();
            bag.Add(initialList);
            bag.Add(addedList);
            
            Assert.That(bag.BackPack, Is.EqualTo(expectedBags.BackPack));
            Assert.That(bag.ExtraBag1, Is.EqualTo(expectedBags.ExtraBag1));
        }

        private static IEnumerable<object[]> GreaterThan8DataSource()
        {
            yield return new object[]
            {
                Items.SpawnItems(6),
                Items.SpawnItems(3),
                new Bags()
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems()
                }
            };
            yield return new object[]
            {
                Items.SpawnItems(8),
                Items.SpawnItems(),
                new Bags()
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems()
                }
            };
            yield return new object[]
            {
                Items.SpawnItems(8),
                Items.SpawnItems(3),
                new Bags()
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems(3)
                }
            };
        }
        
        [TestCaseSource(nameof(GreaterThan4InAnExtraBagDataSource))]
        public void Should_add_items_to_another_extra_bag_when_the_number_of_items_in_an_extra_bag_is_greater_than_4(List<string> initialList,  List<string> addedList, Bags expectedBags)
        {
            var bag = new Bags();
            bag.Add(initialList);
            bag.Add(addedList);
            
            Assert.Multiple(() =>
            {
                Assert.That(bag.BackPack, Is.EqualTo(expectedBags.BackPack));
                Assert.That(bag.ExtraBag1, Is.EqualTo(expectedBags.ExtraBag1));
                Assert.That(bag.ExtraBag2, Is.EqualTo(expectedBags.ExtraBag2));
                Assert.That(bag.BagMetals, Is.EqualTo(expectedBags.BagMetals));
                Assert.That(bag.BagWeapons, Is.EqualTo(expectedBags.BagWeapons));
            });
        }
        
        private static IEnumerable<object[]> GreaterThan4InAnExtraBagDataSource()
        {
            yield return new object[]
            {
                Items.SpawnItems(9),
                Items.SpawnItems(5),
                new Bags
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems(4),
                    ExtraBag2 = {"item", "item"},
                }
            };
            yield return new object[]
            {
                Items.SpawnItems(13),
                Items.SpawnItems(4),
                new Bags
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems(4),
                    ExtraBag2 = Items.SpawnItems(4),
                    BagMetals = Items.SpawnItems()
                }
            };
            yield return new object[]
            {
                Items.SpawnItems(18),
                Items.SpawnItems(3),
                new Bags
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems(4),
                    ExtraBag2 = Items.SpawnItems(4),
                    BagMetals = Items.SpawnItems(4),
                    BagWeapons = Items.SpawnItems()
                }
            };
        }
        
        [TestCaseSource(nameof(GreaterThan4InAnExtraBagDataSource))]
        public void Should_add_an_item_until_all_bags_are_full_ignoring_additional_items(List<string> initialList,  List<string> addedList, Bags expectedBags)
        {
            var bag = new Bags();
            bag.Add(initialList);
            bag.Add(addedList);
            
            Assert.Multiple(() =>
            {
                Assert.That(bag.BackPack, Is.EqualTo(expectedBags.BackPack));
                Assert.That(bag.ExtraBag1, Is.EqualTo(expectedBags.ExtraBag1));
                Assert.That(bag.ExtraBag2, Is.EqualTo(expectedBags.ExtraBag2));
                Assert.That(bag.BagMetals, Is.EqualTo(expectedBags.BagMetals));
                Assert.That(bag.BagWeapons, Is.EqualTo(expectedBags.BagWeapons));
            });
        }

        private static IEnumerable<object[]> FullBagsDataSource()
        {
            yield return new object[]
            {
                Items.SpawnItems(24),
                Items.SpawnItems(1),
                new Bags
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems(4),
                    ExtraBag2 = Items.SpawnItems(4),
                    BagMetals = Items.SpawnItems(4),
                    BagWeapons = Items.SpawnItems(4)
                }
            };
            
            yield return new object[]
            {
                Items.SpawnItems(20),
                Items.SpawnItems(5),
                new Bags
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems(4),
                    ExtraBag2 = Items.SpawnItems(4),
                    BagMetals = Items.SpawnItems(4),
                    BagWeapons = Items.SpawnItems(4)
                }
            };
            
            yield return new object[]
            {
                Items.SpawnItems(15),
                Items.SpawnItems(10),
                new Bags
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems(4),
                    ExtraBag2 = Items.SpawnItems(4),
                    BagMetals = Items.SpawnItems(4),
                    BagWeapons = Items.SpawnItems(4)
                }
            };
        }
        
        [TestCaseSource(nameof(CategorisedItemsBagDataSource))]
        public void Should_organise_bags_according_their_categories_when_organising_spell_is_casted(List<string> initialList,  List<string> addedList, Bags expectedBags)
        {
            var bag = new Bags();
            bag.Add(initialList);
            bag.Add(addedList);
            bag.CastOrganisingSpell();
            
            Assert.Multiple(() =>
            {
                Assert.That(bag.BackPack, Is.EqualTo(expectedBags.BackPack));
                Assert.That(bag.BagMetals, Is.EqualTo(expectedBags.BagMetals));
            });
        }

        private static IEnumerable<object[]> CategorisedItemsBagDataSource()
        {
            yield return new object[]
            {
                new List<string>{"Leather", "Iron", "Copper", "Marigold", "Wool", "Gold", "Silk", "Copper"},
                new List<string>{"Copper", "Cherry Blossom"},
                new Bags
                {
                    BackPack = new List<string> { "Cherry Blossom", "Iron", "Leather", "Marigold", "Silk", "Wool" },
                    BagMetals = new List<string>{ "Copper", "Copper", "Copper", "Gold" }
                }
            };
            
            yield return new object[]
            {
                new List<string>{"Leather", "Iron", "Copper", "Marigold", "Wool", "Gold", "Silk", "Copper", "Gold", "Sword"},
                new List<string>{"Copper", "Cherry Blossom", "Silver", "Mace"},
                new Bags
                {
                    BackPack = new List<string> { "Cherry Blossom", "Gold", "Iron", "Leather", "Marigold", "Silk", "Silver", "Wool" },
                    BagMetals = new List<string>{ "Copper", "Copper", "Copper", "Gold" }
                }
            };
            
            yield return new object[]
            {
                new List<string>{"Leather", "Iron", "Copper", "Marigold", "Wool", "Gold", "Silk", "Copper", "Gold", "Sword", "Linen"},
                new List<string>{"Copper", "Cherry Blossom", "Silver", "Mace", "Axe", "Dagger", "Sword", "Rose", "Axe", "Seaweed"},
                new Bags
                {
                    BackPack = new List<string> { "Cherry Blossom", "Gold", "Iron", "Leather", "Linen", "Marigold", "Rose", "Seaweed" },
                    BagMetals = new List<string>{ "Copper", "Copper", "Copper", "Gold" },
                    ExtraBag1 = new List<string>{ "Silk", "Silver", "Sword", "Sword" },
                    ExtraBag2 = new List<string>{ "Wool"}
                }
            };
        }
    }


    
}
