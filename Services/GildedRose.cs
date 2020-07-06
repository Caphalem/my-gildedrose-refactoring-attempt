using csharp.Constants;
using csharp.Interfaces;
using System.Collections.Generic;

namespace csharp.Services
{
    public class GildedRose : IApplication
    {
        private readonly List<Item> _items;
        private const ushort _maxQuality = 50;
        private const ushort _minQuality = 0;
        private const ushort _backstagePassDoubleQualityThreshold = 10;
        private const ushort _backstagePassTripleQualityThreshold = 5;
        private const ushort _backstagePassZeroQualityThreshold = 0;
        private const ushort _itemDoubleQualityDegradeThreshold = 0;

        public GildedRose(List<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                if (item.Name != ItemNames.Sulfuras)
                {
                    switch (item.Name)
                    {
                        case ItemNames.AgedBrie:
                            item.Quality = HandleAgedBrieQuality(item);
                            break;
                        case ItemNames.BackstagePass:
                            item.Quality = HandleBackstagePassQuality(item);
                            break;
                        default:
                            item.Quality = HandleNormalItemQuality(item);
                            break;
                    }

                    item.SellIn--;
                }
            }
        }

        private int HandleAgedBrieQuality(Item agedBrie)
        {
            if (agedBrie.SellIn <= _itemDoubleQualityDegradeThreshold)
            {
                return IncreaseQuality(agedBrie, 2);
            }
            else
            {
                return IncreaseQuality(agedBrie, 1);
            }
        }

        private int HandleBackstagePassQuality(Item backstagePass)
        {
            if (backstagePass.SellIn <= _backstagePassZeroQualityThreshold)
            {
                return 0;
            }
            else if (backstagePass.SellIn <= _backstagePassTripleQualityThreshold)
            {
                return IncreaseQuality(backstagePass, 3);
            }
            else if (backstagePass.SellIn <= _backstagePassDoubleQualityThreshold)
            {
                return IncreaseQuality(backstagePass, 2);
            }
            else
            {
                return IncreaseQuality(backstagePass, 1);
            }
        }

        private int HandleNormalItemQuality(Item item)
        {
            if (item.SellIn <= _itemDoubleQualityDegradeThreshold)
            {
                return DecreaseQuality(item, 2);
            }
            else
            {
                return DecreaseQuality(item, 1);
            }
        }

        private int IncreaseQuality(Item item, ushort amount)
        {
            if (item.Quality + amount < _maxQuality)
            {
                item.Quality += amount;
            }
            else
            {
                item.Quality = _maxQuality;
            }

            return item.Quality;
        }

        private int DecreaseQuality(Item item, ushort amount)
        {
            if (item.Quality - amount > _minQuality)
            {
                item.Quality -= amount;
            }
            else
            {
                item.Quality = _minQuality;
            }

            return item.Quality;
        }
    }
}
