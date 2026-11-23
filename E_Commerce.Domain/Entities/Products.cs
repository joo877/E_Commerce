using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class Products : BaseEntity<int>
    {
        public  string  Name { get; set; }  = default!;
        public  string Description { get; set; }  = default!;
        public string PictureUrl { get; set; } = default!;
        public  decimal Price { get; set; }

        public Brands ProductBrand { get; set; }
        public int BrandId { get; set; }
        public Types ProductType { get; set; }
        public int TypeId { get; set; }

    }
}
