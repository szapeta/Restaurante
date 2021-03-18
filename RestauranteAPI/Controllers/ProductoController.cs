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

        public List<ProductoMDL> GetProducto(int id)
        {
            var resultado = new List<ProductoMDL>();

            ProductoDB productodb = new ProductoDB(null);
            string err = "";
            DataSet res = productodb.GetFuncionFiltrar(id, ref err);

            if (res != null && res.Tables.Count > 0 && res.Tables[0].Rows.Count > 0)
            {
                resultado = res.Tables[0].ToList<ProductoMDL>();
            }
            return resultado;
        }

        public bool PostProducto([FromBody] ProductoMDL objProducto)
        {
            bool resp = false;
            int agregar = 1;
            ProductoMDL objInsertar = objProducto;
            try
            {
                string msg = string.Empty;
                ProductoDB service = new ProductoDB(objInsertar);
                resp = service.AGREGAR_ACTUALIZAR(agregar, ref msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return resp;
        }

        public bool PutProducto([FromBody] ProductoMDL objProducto)
        {
            bool resp = false;
            int actualizar = 2;
            ProductoMDL objInsertar = objProducto;
            try
            {
                string msg = string.Empty;
                ProductoDB service = new ProductoDB(objInsertar);
                resp = service.AGREGAR_ACTUALIZAR(actualizar, ref msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return resp;
        }

        public bool DeleteProducto(int id) 
        {
            bool resp = false;

            try
            {
                string msg = string.Empty;
                ProductoDB service = new ProductoDB(null);
                resp = service.Eliminar(id, ref msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return resp;
        }
    }
}
