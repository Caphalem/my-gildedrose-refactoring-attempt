using csharp.Interfaces;
using csharp.Models;
using csharp.Services;
using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        private static ushort _days = 31;
        private static ILogger _logger = new BasicConsoleLogger();
        private static readonly ItemUtils _itemUtils = new ItemUtils(_logger);
        private static readonly List<ExtendedItem> _items = _itemUtils.InitializeItems();
        private static IApplication _app = new GildedRose(_items);

        public Program(ushort days, ILogger logger, IApplication app)
        {
            _days = days;
            _logger = logger;
            _app = app;
        }

        public static void Main(string[] args)
        {
            try
            {
                _logger.Info("OMGHAI!");

                for (ushort i = 0; i < _days; i++)
                {
                    _itemUtils.ListItems(_items, i);

                    _app.UpdateQuality();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Message: {ex.Message} StackTrace: {ex.StackTrace}");
            }
        }
    }
}
