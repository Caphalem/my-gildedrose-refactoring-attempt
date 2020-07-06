﻿using csharp.Constants;
using csharp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        private List<Item> items;
        private GildedRose app;
        private ItemNames names;

        [SetUp]
        public void Setup()
        {
            items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 1 } };
            app = new GildedRose(items);
            names = new ItemNames();
        }

        [Test]
        public void ShouldDecreaseItemSellInAfterUpdateQualityBy1()
        {
            app.UpdateQuality();

            Assert.AreEqual(0, items[0].SellIn);
        }

        [Test]
        public void ShouldDecreaseItemQualityAfterUpdateQualityBy1()
        {
            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void ShouldDecreaseItemQualityAfterUpdateQualityBy2IfSellInIs0()
        {
            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void ShouldNotDecreaseItemQualityAfterUpdateQualityIfQualityIs0()
        {
            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void ShouldIncreaseAgedBrieItemQualityAfterUpdateQualityBy1()
        {
            items = new List<Item> { new Item { Name = names.AgedBrie, SellIn = 1, Quality = 0 } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(1, items[0].Quality);
        }

        [Test]
        public void ShouldNotIncreaseAgedBrieItemQualityAfterUpdateQualityIfQualityIs50()
        {
            items = new List<Item> { new Item { Name = names.AgedBrie, SellIn = 1, Quality = 50 } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void ShouldNotChangeItemSellInOrQualityValuesIfItemNameIsSulfuras()
        {
            items = new List<Item> { new Item { Name = names.Sulfuras, SellIn = 1, Quality = 1 } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(1, items[0].Quality);
            Assert.AreEqual(1, items[0].SellIn);
        }

        [Test]
        public void ShouldIncreaseBackstagePassItemQualityAfterUpdateQualityBy1()
        {
            items = new List<Item> { new Item { Name = names.BackstagePass, SellIn = 20, Quality = 1 } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(2, items[0].Quality);
        }

        [TestCase(10)]
        [TestCase(9)]
        [TestCase(8)]
        [TestCase(7)]
        [TestCase(6)]
        public void ShouldIncreaseBackstagePassItemQualityAfterUpdateQualityBy2IfSellInIsBetween11And5Exclusive(int sellIn)
        {
            items = new List<Item> { new Item { Name = names.BackstagePass, SellIn = sellIn, Quality = 1 } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(3, items[0].Quality);
        }

        [TestCase(5)]
        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void ShouldIncreaseBackstagePassItemQualityAfterUpdateQualityBy3IfSellInIsBetween6And0Exclusive(int sellIn)
        {
            items = new List<Item> { new Item { Name = names.BackstagePass, SellIn = sellIn, Quality = 1 } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(4, items[0].Quality);
        }

        [Test]
        public void ShouldSetBackstagePassItemQualityAfterUpdateQualityTo0IfSellInIs0()
        {
            items = new List<Item> { new Item { Name = names.BackstagePass, SellIn = 0, Quality = 10 } };
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
        public void ShouldNotIncreaseBackstagePassItemQualityAfterUpdateQualityIfQualityIs50(int sellIn)
        {
            items = new List<Item> { new Item { Name = names.BackstagePass, SellIn = sellIn, Quality = 50 } };
            app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(50, items[0].Quality);
        }
    }
}
