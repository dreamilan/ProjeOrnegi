using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSurrogate
{
    public class TB_ProductSurrogate
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public Decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        public TB_ColorSurrogate Color { get; set; }
        public TB_CitySurrogate City { get; set; }
        public TB_CategorySurrogate Category { get; set; }
    }
}
