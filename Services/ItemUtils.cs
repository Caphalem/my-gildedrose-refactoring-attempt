using csharp.Constants;
using csharp.Interfaces;
using csharp.Models;
using System.Collections.Generic;

namespace csharp.Services
{
    public class ItemUtils
    {
        private readonly ILogger _logger;

        public ItemUtils(ILogger logger)
        {
            _logger = logger;
        }

        public List<ExtendedItem> InitializeItems()
        {
            return new List<ExtendedItem> {
                new ExtendedItem
                {
                    Name = ItemNames.DexterityVest,
                    SellIn = 10,
                    Quality = 20,
                    Type = ItemType.Normal
                },
                new ExtendedItem
                {
                    Name = ItemNames.AgedBrie,
                    SellIn = 2,
                    Quality = 0,
                    Type = ItemType.Aging
                },
                new ExtendedItem
                {
                    Name = ItemNames.MongooseElixir,
                    SellIn = 5,
                    Quality = 7,
                    Type = ItemType.Normal
                },
                new ExtendedItem
                {
                    Name = ItemNames.Sulfuras,
                    SellIn = 0,
                    Quality = 80,
                    Type = ItemType.Legendary
                },
                new ExtendedItem
                {
                    Name = ItemNames.Sulfuras,
                    SellIn = -1,
                    Quality = 80,
                    Type = ItemType.Legendary
                },
                new ExtendedItem
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 15,
                    Quality = 20,
                    Type = ItemType.Concert
                },
                new ExtendedItem
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 10,
                    Quality = 49,
                    Type = ItemType.Concert
                },
                new ExtendedItem
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 5,
                    Quality = 49,
                    Type = ItemType.Concert
                },
				
				new ExtendedItem
                {
                    Name = ItemNames.ConjuredManaCake,
                    SellIn = 3,
                    Quality = 6,
                    Type = ItemType.Conjured
                }
            };
        }

        public void ListItems(List<ExtendedItem> items, ushort currentDay)
        {
            _logger.Info("-------- day " + currentDay + " --------");
            _logger.Info("name, sellIn, quality");

            items.ForEach(item => _logger.Info(item.ToString()));

            _logger.Info("");
        }
    }
}
