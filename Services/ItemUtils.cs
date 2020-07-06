using csharp.Constants;
using csharp.Interfaces;
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

        public List<Item> InitializeItems()
        {
            return new List<Item> {
                new Item
                {
                    Name = ItemNames.DexterityVest,
                    SellIn = 10,
                    Quality = 20
                },
                new Item
                {
                    Name = ItemNames.AgedBrie,
                    SellIn = 2,
                    Quality = 0
                },
                new Item
                {
                    Name = ItemNames.MongooseElixir,
                    SellIn = 5,
                    Quality = 7},
                new Item
                {
                    Name = ItemNames.Sulfuras,
                    SellIn = 0,
                    Quality = 80
                },
                new Item
                {
                    Name = ItemNames.Sulfuras,
                    SellIn = -1,
                    Quality = 80
                },
                new Item
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item
                {
                    Name = ItemNames.ConjuredManaCake,
                    SellIn = 3,
                    Quality = 6
                }
            };
        }

        public void ListItems(List<Item> items, ushort currentDay)
        {
            _logger.Info("-------- day " + currentDay + " --------");
            _logger.Info("name, sellIn, quality");

            items.ForEach(item => _logger.Info(item.ToString()));

            _logger.Info("");
        }
    }
}
