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
    internal class Login
    {

        public static bool verificaLogin(string correo, string contra)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = $"https://localhost:7027/Usuarios/valida?correo={correo}&contra={contra}";

                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

                    var responseMessage= httpClient.GetAsync("").GetAwaiter().GetResult();
                    string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
                    bool responseObj=JsonConvert.DeserializeObject<bool>(responseJson);
                    return responseObj;

                }


            }catch (Exception ex)
            {
                return false;
            }

            
        }

    }
}
