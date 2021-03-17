using RestauranteMODEL.Model;
using RestauranteWEB.Peticion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestauranteWEB.Producto
{
    public partial class ProductoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            obtenerDatosAsync();

        }

        public async Task<bool> obtenerDatosAsync()
        {

            try
            {
                WebServiceClient cliente = new WebServiceClient();
                    var dato = cliente.GetListByIdWS<ProductoMDL>("api/producto/GetProductos");
             
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }
    }
}