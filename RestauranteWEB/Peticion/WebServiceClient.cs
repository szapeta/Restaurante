using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


namespace RestauranteWEB.Peticion
{
    public class WebServiceClient
    {
        public string WebServiceBaseUrl = "http://localhost:64963/";
        public async Task<List<Tout>> GetListByIdWS<Tout>(string urlMetodoWithId)
        {
            List<Tout> respuesta = default(List<Tout>);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebServiceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlMetodoWithId);
                    if (response.IsSuccessStatusCode)
                    {
                        respuesta = await response.Content.ReadAsAsync<List<Tout>>();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        throw new HttpRequestException(error);
                    }
                }
                catch (HttpRequestException e)
                {
                    // Handle exception.
                    throw;
                }
                catch (Exception ex)
                {
                    // Handle exception.
                    throw;
                }
            }

            return respuesta;
        }
    }
}