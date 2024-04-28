using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT
{
    
    interface Product
    {
        string UnitOfMeasure { get;}
        int Amount { get; set; }
    }
    class ProductsList
    {
        private List<Product> list;
        public List<Product> List { get { return list; } }
        public ProductsList()
        {
            list = new List<Product>();
        }
        public void InsertElement(Product newProduct)
        {
            this.list.Add(newProduct);
        }
        public void WriteOutList()
        {
            foreach (var product in list)
            {
                Console.WriteLine($"Product type: {product.GetType().Name}");
                Console.WriteLine($"Amount: {product.Amount} {product.UnitOfMeasure}");
                Console.WriteLine();
            }
        }
    }
}
