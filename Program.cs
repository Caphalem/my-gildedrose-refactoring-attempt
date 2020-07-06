using csharp.Constants;
using csharp.Interfaces;
using csharp.Services;
using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        private static ushort _days = 31;
        private static ILogger _logger = new BasicConsoleLogger();
        private static readonly ItemNames _names = new ItemNames();

        public Program(ushort days, ILogger logger)
        {
            _days = days;
            _logger = logger;
        }

        public static void Main(string[] args)
        {
            try
            {
                _logger.Info("OMGHAI!");

                List<Item> items = InitializeItems();

                var app = new GildedRose(items);

                for (ushort i = 0; i < _days; i++)
                {
                    ListItems(items, i);

                    app.UpdateQuality();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Message: {ex.Message} StackTrace: {ex.StackTrace}");
            }
        }

        private static List<Item> InitializeItems()
        {
            return new List<Item> {
                new Item
                {
                    Name = _names.DexterityVest,
                    SellIn = 10,
                    Quality = 20
                },
                new Item
                {
                    Name = _names.AgedBrie,
                    SellIn = 2,
                    Quality = 0
                },
                new Item
                {
                    Name = _names.MongooseElixir,
                    SellIn = 5,
                    Quality = 7},
                new Item
                {
                    Name = _names.Sulfuras,
                    SellIn = 0,
                    Quality = 80
                },
                new Item
                {
                    Name = _names.Sulfuras,
                    SellIn = -1,
                    Quality = 80
                },
                new Item
                {
                    Name = _names.BackstagePass,
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = _names.BackstagePass,
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = _names.BackstagePass,
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item
                {
                    Name = _names.ConjuredManaCake,
                    SellIn = 3,
                    Quality = 6
                }
            };
        }

        private static void ListItems(List<Item> items, ushort currentDay)
        {
            _logger.Info("-------- day " + currentDay + " --------");
            _logger.Info("name, sellIn, quality");

            items.ForEach((x) => _logger.Info(x.ToString()));

            _logger.Info("");
        }
    }
}
