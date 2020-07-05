using ApprovalUtilities.Utilities;
using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        private static ushort _days = 31;

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> items = InitializeItems();

            var app = new GildedRose(items);

            for (ushort i = 0; i < _days; i++)
            {
                ListItems(items, i);

                app.UpdateQuality();
            }
        }

        private static IList<Item> InitializeItems()
        {
            return new List<Item> {
                new Item
                {
                    Name = "+5 Dexterity Vest",
                    SellIn = 10,
                    Quality = 20
                },
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 2,
                    Quality = 0
                },
                new Item
                {
                    Name = "Elixir of the Mongoose",
                    SellIn = 5,
                    Quality = 7},
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 0,
                    Quality = 80
                },
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = -1,
                    Quality = 80
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 3,
                    Quality = 6
                }
            };
        }

        private static void ListItems(IList<Item> items, ushort currentDay)
        {
            Console.WriteLine("-------- day " + currentDay + " --------");
            Console.WriteLine("name, sellIn, quality");

            items.ForEach((x) => Console.WriteLine(x));

            Console.WriteLine("");
        }
    }
}
