using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Produto.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();
        private int _nextId = 1;

        public ProdutoRepositorio()
        {
            //Add(new Produto
            //{
            //    sku = 43264,
            //    name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            //    inventory = new Inventory() {
            //        werehouses = new List<Werehouse>
            //        {
            //            new Werehouse{
            //                locality = "SP", quality = 12, type = "ECOMMERCE"
            //            },
            //            new Werehouse{
            //                locality = "MOEMA", quality = 3, type = "PHYSICAL_STORE"
            //            }
            //        }
            //    }
            //});
        }

        public Produto Add(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            
            produtos.Add(item);
            return item;
        }

        public Produto Get(int sku)
        {
            return produtos.Find(p => p.sku == sku);
        }

        public IEnumerable<Produto> GetAll()
        {
            return produtos;
        }

        public void Remove(int sku)
        {
            produtos.RemoveAll(p => p.sku == sku);
        }

        public bool Update(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = produtos.FindIndex(p => p.sku == item.sku);

            if (index == -1)
            {
                return false;
            }
            produtos.RemoveAt(index);
            produtos.Add(item);
            return true;
        }
    }
}