namespace csharp.Models
{
    // I may not be allowed to change Item.cs but that sure as hell doesn't apply to extending it :P
    public enum ItemType
    {
        Normal,
        Aging,
        Concert,
        Legendary,
        Conjured
    }

    public class ExtendedItem : Item
    {
        public ItemType Type { get; set; }
    }
}
