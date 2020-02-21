using System.Collections.Generic;

namespace WebAPI_Produto.Models
{
    public class Inventory
    {
        public int quality { get; set; }
        public List<Werehouse> werehouses { get; set; }

        //public Inventory(int quality, List<Werehouse> werehouse)
        //{
        //    this.quality = quality;
        //    this.werehouses = werehouse;
        //}
    }
}