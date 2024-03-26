using GetechnologiesMxFront.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GetechnologiesMxFront.Funciones
{
    internal class Facturas
    {

        public static List<Factura> GetFacturas(int idPersona)
        {
            List<Factura> list= new List<Factura>();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = $"https://localhost:7027/Facturas/getFacturasByIdPersona?idPersona={idPersona}";

                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

                    var responseMessage = httpClient.GetAsync("").GetAwaiter().GetResult();
                    string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
                    List<Factura> responseObj = JsonConvert.DeserializeObject<List<Factura>>(responseJson);
                    return responseObj;

                }


            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public static Factura crearFactura(Factura factura)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = "https://localhost:7027/Facturas/createFactura";

                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonString = JsonConvert.SerializeObject(factura);
                    HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var request = httpClient.PostAsync("", content).GetAwaiter().GetResult();
                    string response = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Factura responseObj = JsonConvert.DeserializeObject<Factura>(response);
                    return responseObj;
                }
            }
            catch (Exception ex)
            {
                return factura = new Factura();
            }
        }
    }
}
