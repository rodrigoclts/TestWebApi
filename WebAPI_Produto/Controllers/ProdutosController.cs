using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Produto.Models;

namespace WebAPI_Produto.Controllers
{
    public class ProdutosController : ApiController
    {
        static readonly IProdutoRepositorio repositorio = new ProdutoRepositorio();

        public IEnumerable<Produto> GetAllProdutos()
        {
            return repositorio.GetAll();
        }

        public Produto GetProduto(int id)
        {
            Produto item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Produto> GetProdutosPorCategoria(string categoria)
        {
            return repositorio.GetAll().Where(
                p => string.Equals(p.name, categoria, StringComparison.OrdinalIgnoreCase));
        }
        [HttpPost]
        public HttpResponseMessage PostProduto(JObject jsonResult)
        {

            Produto item = JsonConvert.DeserializeObject<Produto>(jsonResult.ToString());
            //return jsonResult;

            //Produto deserializedProduto = JsonConvert.DeserializeObject<Produto>(produto);

            item = repositorio.Add(item);

            if (item == null)
            {
                var message = string.Format("Product with id = {0} not found", item.sku);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
        }

        public void PutProduto(int id, Produto produto)
        {
            produto.sku = id;
            if (!repositorio.Update(produto))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProduto(int id)
        {
            Produto item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(id);
        }
    }
}

