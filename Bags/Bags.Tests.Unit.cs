using System.Collections.Generic;
using System.Text.Json;
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
            var item = new Item();
            bag.Add(item);
            Assert.That(bag.BackPack.Contains(item));
        }
        
        [TestCaseSource(nameof(LessThan8DataSource))]
        public void Should_add_items_in_the_backpack_while_the_number_of_items_is_less_than_8(List<Item> initialList, List<Item> addedList, Bags expectedBags)
        {
            var bag = new Bags();
            bag.Add(initialList);
            bag.Add(addedList);
            
            Assert.Multiple(() =>
            {
                Assert.That(bag.BackPack.Count <= 8);
                Assert.That(bag.BackPack.Count, Is.EqualTo(expectedBags.BackPack.Count));
            });
        }

        private static IEnumerable<object[]> LessThan8DataSource()
        {
            yield return new object[]
            {
                Items.SpawnItems(),
                Items.SpawnItems(3),
                new Bags()
                {
                    BackPack = Items.SpawnItems(4)
                }
            };
            
            yield return new object[]
            {
                Items.SpawnItems(7),
                Items.SpawnItems(),
                new Bags()
                {
                    BackPack = Items.SpawnItems(8)
                }
            };
            
            yield return new object[]
            {
                Items.SpawnItems(6),
                Items.SpawnItems(3),
                new Bags()
                {
                    BackPack = Items.SpawnItems(8)
                }
            };
        }

        [TestCaseSource(nameof(GreaterThan8DataSource))]
        public void Should_add_items_to_an_extra_bag_when_the_number_of_items_is_greater_than_8(List<Item> initialList, List<Item> addedList, Bags expectedBags)
        {
            var bag = new Bags();
            bag.Add(initialList);
            bag.Add(addedList);
            
            
            Assert.Multiple(() =>
            {
                Assert.That(bag.BackPack.Count, Is.EqualTo(expectedBags.BackPack.Count));
                Assert.That(bag.ExtraBag1.Count, Is.EqualTo(expectedBags.ExtraBag1.Count));
            });
        }

        private static IEnumerable<object[]> GreaterThan8DataSource()
        {
            yield return new object[]
            {
                Items.SpawnItems(7),
                Items.SpawnItems(3),
                new Bags()
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems(2),
                }
            };
            yield return new object[]
            {
                Items.SpawnItems(5),
                Items.SpawnItems(4),
                new Bags()
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems()
                }
            };
            yield return new object[]
            {
                Items.SpawnItems(7),
                Items.SpawnItems(6),
                new Bags()
                {
                    BackPack = Items.SpawnItems(8),
                    ExtraBag1 = Items.SpawnItems(4)
                }
            };
        }
        
        [TestCaseSource(nameof(GreaterThan4InAnExtraBagDataSource))]
        public void Should_add_items_to_another_extra_bag_when_the_number_of_items_in_an_extra_bag_is_greater_than_4(List<Item> initialList,  List<Item> addedList, Bags expectedBags)
        {
            var bag = new Bags();
            bag.Add(initialList);
            bag.Add(addedList);
            
            Assert.Multiple(() =>
            {
                Assert.That(bag.BackPack.Count, Is.EqualTo(expectedBags.BackPack.Count));
                Assert.That(bag.ExtraBag1.Count, Is.EqualTo(expectedBags.ExtraBag1.Count));
                Assert.That(bag.ExtraBag2.Count, Is.EqualTo(expectedBags.ExtraBag2.Count));
                Assert.That(bag.BagMetals.Count, Is.EqualTo(expectedBags.BagMetals.Count));
                Assert.That(bag.BagWeapons.Count, Is.EqualTo(expectedBags.BagWeapons.Count));
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
                    ExtraBag2 = Items.SpawnItems(2),
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
        
        [Test]
        public void Should_add_an_item_until_all_bags_are_full_ignoring_additional_items()
        {
            var bag = new Bags();
            bag.Add(Items.SpawnItems(23));
            bag.Add(Items.SpawnItems(2));
            
            Assert.Multiple(() =>
            {
                Assert.That(bag.BackPack.Count, Is.EqualTo(8));
                Assert.That(bag.ExtraBag1.Count, Is.EqualTo(4));
                Assert.That(bag.ExtraBag2.Count, Is.EqualTo(4));
                Assert.That(bag.BagMetals.Count, Is.EqualTo(4));
                Assert.That(bag.BagWeapons.Count, Is.EqualTo(4));
            });
        }
       
        [Test]
        [TestCaseSource(nameof(CategorisedItemsBagDataSource))]
        public void Should_organise_bags_according_their_categories_when_organising_spell_is_casted(List<Item> initialList,  List<Item> addedList, Bags expectedBags)
        {
            var bag = new Bags();
            bag.Add(initialList);
            bag.Add(addedList);
            bag.CastOrganisingSpell();
            
            Assert.Multiple(() =>
            {
                Assert.That(JsonSerializer.Serialize(bag.BackPack), Is.EqualTo(JsonSerializer.Serialize(expectedBags.BackPack)));
                Assert.That(JsonSerializer.Serialize(bag.BagMetals), Is.EqualTo(JsonSerializer.Serialize(expectedBags.BagMetals)));
            });
        }
        
        private static IEnumerable<object[]> CategorisedItemsBagDataSource()
        {
            yield return new object[]
            {
                new List<Item>{
                    new Cloth("Leather"), 
                    new Metal("Iron"), 
                    new Metal("Copper"), 
                    new Herb("Marigold"), 
                    new Cloth("Wool"), 
                    new Metal("Gold"), 
                    new Cloth("Silk"), 
                    new Metal("Copper")
                },
                new List<Item>
                {
                    new Metal("Copper"), 
                    new Herb("Cherry Blossom")
                },
                new Bags
                {
                    BackPack = new List<Item>
                    {
                        new Herb("Cherry Blossom"),
                        new Metal("Iron"), 
                        new Cloth("Leather"), 
                        new Herb("Marigold"), 
                        new Cloth("Silk"),
                        new Cloth("Wool")
                    },
                    BagMetals = new List<Item>
                    {
                        new Metal("Copper"),
                        new Metal("Copper"),
                        new Metal("Copper"),
                        new Metal("Gold")
                    }
                }
            };
        }
    }
}
