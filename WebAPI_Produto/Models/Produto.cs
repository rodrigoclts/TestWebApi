using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Produto.Models
{
    public class Produto
    {
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public bool isMarketable { get; set; }

        //public Produto(int sku, string name, Inventory inventory, bool isMarketble)
        //{
        //    this.sku = sku;
        //    this.name = name;
        //    this.inventory = inventory;
        //    isMarketable = isMarketable;
        //}
    }
}