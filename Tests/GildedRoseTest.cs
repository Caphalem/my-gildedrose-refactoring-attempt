using csharp.Constants;
using csharp.Models;
using csharp.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        private List<ExtendedItem> items;
        private GildedRose app;

        [SetUp]
        public void Setup()
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = "foo", SellIn = 5, Quality = 5, Type = ItemType.Normal } };
            app = new GildedRose(items);
        }

        [Test]
        public void ShouldDecreaseNormalItemSellInAfterUpdateQualityBy1()
        {
            app.UpdateQuality();

            Assert.AreEqual(4, items[0].SellIn);
        }

        [Test]
        public void ShouldDecreaseNormalItemQualityAfterUpdateQualityBy1()
        {
            app.UpdateQuality();

            Assert.AreEqual(4, items[0].Quality);
        }

        [Test]
        public void ShouldDecreaseNormalItemQualityAfterUpdateQualityBy2IfSellInIs0()
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = "foo", SellIn = 0, Quality = 5, Type = ItemType.Normal } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(3, items[0].Quality);
        }

        [Test]
        public void ShouldNotDecreaseNormalItemQualityBelow0AfterUpdateQualityIfSellInIs0AndQualityIs1()
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = "foo", SellIn = 0, Quality = 1, Type = ItemType.Normal } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void ShouldNotDecreaseNormalItemQualityAfterUpdateQualityIfQualityIs0()
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = "foo", SellIn = 5, Quality = 0, Type = ItemType.Normal } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void ShouldIncreaseAgingItemQualityAfterUpdateQualityBy1()
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.AgedBrie, SellIn = 1, Quality = 0, Type = ItemType.Aging } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(1, items[0].Quality);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ShouldIncreaseAgingItemQualityAfterUpdateQualityBy2IfSellInIs0OrLower(int sellIn)
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.AgedBrie, SellIn = sellIn, Quality = 10, Type = ItemType.Aging } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(12, items[0].Quality);
        }

        [TestCase(1, 50)]
        [TestCase(0, 49)]
        [TestCase(-1, 49)]
        public void ShouldNotIncreaseAgingItemQualityAbove50AfterUpdateQuality(int sellIn, int quality)
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.AgedBrie, SellIn = sellIn, Quality = quality, Type = ItemType.Aging } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void ShouldNotChangeLegendaryItemSellInOrQualityValues()
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.Sulfuras, SellIn = 1, Quality = 1, Type = ItemType.Legendary } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(1, items[0].Quality);
            Assert.AreEqual(1, items[0].SellIn);
        }

        [Test]
        public void ShouldIncreaseConcertItemQualityAfterUpdateQualityBy1()
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.BackstagePass, SellIn = 20, Quality = 1, Type = ItemType.Concert } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(2, items[0].Quality);
        }

        [TestCase(10)]
        [TestCase(9)]
        [TestCase(8)]
        [TestCase(7)]
        [TestCase(6)]
        public void ShouldIncreaseConcertItemQualityAfterUpdateQualityBy2IfSellInIsBetween11And5Exclusive(int sellIn)
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.BackstagePass, SellIn = sellIn, Quality = 1, Type = ItemType.Concert } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(3, items[0].Quality);
        }

        [TestCase(5)]
        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void ShouldIncreaseConcertItemQualityAfterUpdateQualityBy3IfSellInIsBetween6And0Exclusive(int sellIn)
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.BackstagePass, SellIn = sellIn, Quality = 1, Type = ItemType.Concert } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(4, items[0].Quality);
        }

        [Test]
        public void ShouldSetConcertItemQualityAfterUpdateQualityTo0IfSellInIs0()
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.BackstagePass, SellIn = 0, Quality = 10, Type = ItemType.Concert } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [TestCase(11)]
        [TestCase(10)]
        [TestCase(9)]
        [TestCase(8)]
        [TestCase(7)]
        [TestCase(6)]
        [TestCase(5)]
        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void ShouldNotIncreaseConcertItemQualityAfterUpdateQualityIfQualityIs50(int sellIn)
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.BackstagePass, SellIn = sellIn, Quality = 50, Type = ItemType.Concert } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void ShouldDecreaseConjuredItemQualityBy2AfterUpdateQuality()
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.ConjuredManaCake, SellIn = 1, Quality = 50, Type = ItemType.Conjured } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(48, items[0].Quality);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ShouldDecreaseConjuredItemQualityBy4AfterUpdateQualityIfSellInIs0OrLower(int sellIn)
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.ConjuredManaCake, SellIn = sellIn, Quality = 50, Type = ItemType.Conjured } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(46, items[0].Quality);
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        public void ShouldNotDecreaseConjuredItemQualityBelow0AfterUpdateQuality(int sellIn)
        {
            items = new List<ExtendedItem> { new ExtendedItem { Name = ItemNames.ConjuredManaCake, SellIn = sellIn, Quality = 2, Type = ItemType.Conjured } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }
    }
}
