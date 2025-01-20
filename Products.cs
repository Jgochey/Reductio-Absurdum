namespace raa
{
    class Product
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public bool Sold { get; set; }

        public int ProductId { get; set; }

        public required string ProductType { get; set; }
        public int ProductTypeId { get; set; }
                // 1 - Appareal, 2 - Potion, 3 - Enchanted Object, 4 - Wand

        public DateTime DateStocked { get; set; }

        public int DaysOnShelf
        {
            get
            {
                TimeSpan timeOnShelf = DateTime.Now - DateStocked;
                return timeOnShelf.Days;
            }
        }

    }
}
