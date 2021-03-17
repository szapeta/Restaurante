using RestauranteDATA;
using RestauranteMODEL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Controllers
{
    public class ProductoController : ApiController
    {
        public List<ProductoMDL> GetProductos() 
        {
            var resultado = new List<ProductoMDL>();

            ProductoDB productodb = new ProductoDB(null);
            string err = "";
            DataSet res = productodb.TODO(ref err);

            if (res != null && res.Tables.Count > 0 && res.Tables[0].Rows.Count > 0)
            {
                resultado = res.Tables[0].ToList<ProductoMDL>();
            }
            return resultado;
        }

        public string GetProducto(int id)
        {
            return "id: "+ id.ToString();
        }

        public HttpResponseMessage PostProducto(string s)
        {
            
            return null;
        }

        public bool PutProducto(int id, string producto)
        {
            return true;
        }

        public bool DeleteProducto(int id) 
        {
            return true;
        }
    }
}
