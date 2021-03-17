using RestauranteMODEL.Model;
using RestauranteWEB.Peticion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public void obtenerDatosAsync()
        {
            var url = $"http://localhost:64963/api/producto";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null)
                        { return;
                        }
                            
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                // Handle error
            }

        }
    }
}