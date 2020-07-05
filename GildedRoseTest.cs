using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void ShouldDecreaseItemSellInAndQualityAfterUpdateQualityByOne()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);
        }
    }
}
