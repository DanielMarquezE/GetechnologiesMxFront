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
    internal class Registro
    {

        public static Usuario incribir(Usuario usuario)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = "https://localhost:7027/Usuarios/creaUsuario";

                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonString=JsonConvert.SerializeObject(usuario);
                    HttpContent content= new StringContent(jsonString,Encoding.UTF8, "application/json");

                    var request = httpClient.PostAsync("",content).GetAwaiter().GetResult();
                    string response = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Usuario responseObj = JsonConvert.DeserializeObject<Usuario>(response);
                    return responseObj;
                }
            }
            catch(Exception ex)
            {
                return usuario= new Usuario();
            }           
        }

    }
}
