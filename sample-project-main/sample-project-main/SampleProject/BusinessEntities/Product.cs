using System;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        private string _name;
        private decimal _price;
        private string _category;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public decimal Price
        {
            get => _price;
            private set => _price = value;
        }

        public string Category
        {
            get => _category;
            private set => _category = value;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Product name is required.");
            _name = name;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be non-negative.");
            _price = price;
        }

        public void SetCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentNullException(nameof(category), "Category is required.");
            _category = category;
        }
    }

}
