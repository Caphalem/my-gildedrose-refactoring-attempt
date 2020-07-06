using csharp.Constants;
using csharp.Interfaces;
using csharp.Models;
using System.Collections.Generic;

namespace csharp.Services
{
    public class GildedRose : IApplication
    {
        private readonly List<ExtendedItem> _items;
        private const ushort _maxQuality = 50;
        private const ushort _minQuality = 0;
        private const ushort _backstagePassDoubleQualityThreshold = 10;
        private const ushort _backstagePassTripleQualityThreshold = 5;
        private const ushort _backstagePassZeroQualityThreshold = 0;
        private const ushort _itemDoubleQualityDegradeThreshold = 0;

        public GildedRose(List<ExtendedItem> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (ExtendedItem item in _items)
            {
                switch (item.Type)
                {
                    case ItemType.Legendary:
                        item.SellIn++;
                        break;
                    case ItemType.Aging:
                        item.Quality = HandleAgingItemQuality(item);
                        break;
                    case ItemType.Concert:
                        item.Quality = HandleConcertItemQuality(item);
                        break;
                    case ItemType.Conjured: // comment this case out for GoldenMaster to work
                        item.Quality = HandleConjuredItemQuality(item);
                        break;
                    default:
                        item.Quality = HandleNormalItemQuality(item);
                        break;
                }

                item.SellIn--;
            }
        }

        private int HandleAgingItemQuality(ExtendedItem agedBrie)
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

        private int HandleConcertItemQuality(ExtendedItem backstagePass)
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

        private int HandleNormalItemQuality(ExtendedItem item)
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

        private int HandleConjuredItemQuality(ExtendedItem item)
        {
            if (item.SellIn <= _itemDoubleQualityDegradeThreshold)
            {
                return DecreaseQuality(item, 4);
            }
            else
            {
                return DecreaseQuality(item, 2);
            }
        }

        private int IncreaseQuality(ExtendedItem item, ushort amount)
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

        private int DecreaseQuality(ExtendedItem item, ushort amount)
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
