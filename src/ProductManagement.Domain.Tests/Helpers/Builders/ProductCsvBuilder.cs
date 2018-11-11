using System;
using ProductManagement.Domain.Products.Csv;

namespace ProductManagement.Domain.Tests.Helpers.Builders
{
    public class ProductCsvBuilder
    {
        private string _key = "1";
        private string _artikleCode = "d21d";
        private string _colorCode = "jeans";
        private string _description = "vandf";
        private decimal _price = 10m;
        private decimal _discountPrice = 15m;
        private string _deliveredIn = "2 business days";
        private string _q1 = "boy";
        private int _size = 54;
        private string _color = "blue";

        public static ProductCsvBuilder AProductCsv() 
        {
            return new ProductCsvBuilder();
        }

        public ProductCsv Build()
        {
            return new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _q1, _size, _color);
        }

        public ProductCsvBuilder WithKey(string key)
        {
            _key = key;
            return this;
        }

        public ProductCsvBuilder WithArtikleCode(string artikleCode)
        {
            _artikleCode = artikleCode;
            return this;
        }

        public ProductCsvBuilder WithColorCode(string colorCode)
        {
            _colorCode = colorCode;
            return this;
        }

        public ProductCsvBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ProductCsvBuilder WithDeliveredIn(string deliveredIn)
        {
            _deliveredIn = deliveredIn;
            return this;
        }

        public ProductCsvBuilder WithQ1(string q1)
        {
            _q1 = q1;
            return this;
        }

        public ProductCsvBuilder WithColor(string color)
        {
            _color = color;
            return this;
        }
    }
}