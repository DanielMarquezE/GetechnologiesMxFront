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
    internal class Personas
    {

        public static List<Persona> getPersonas()
        {
            List<Persona> list = new List<Persona>();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = $"https://localhost:7027/Personas/getPersonas";

                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

                    var responseMessage = httpClient.GetAsync("").GetAwaiter().GetResult();
                    string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
                    List<Persona> responseObj = JsonConvert.DeserializeObject<List<Persona>>(responseJson);
                    return responseObj;

                }


            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public static Persona getPersonasByID(int idPersona)
        {
            Persona list = new Persona();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = $"https://localhost:7027/Personas/getPersonaById?idPersona={idPersona}";

                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

                    var responseMessage = httpClient.GetAsync("").GetAwaiter().GetResult();
                    string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
                    Persona responseObj = JsonConvert.DeserializeObject<Persona>(responseJson);
                    return responseObj;

                }


            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public static Persona eliminarPersonaById(int idPersona)
        {
            Persona persona = new Persona();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = $"https://localhost:7027/Personas/deletePersona?idPersona={idPersona}";

                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var request = httpClient.DeleteAsync("").GetAwaiter().GetResult();
                    string response = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Persona responseObj = JsonConvert.DeserializeObject<Persona>(response);
                    return responseObj;
                }
            }
            catch (Exception ex)
            {
                return persona = new Persona();
            }
        }

        public static Persona crearPersona(Persona persona)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = "https://localhost:7027/Personas/insertPersona";

                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonString = JsonConvert.SerializeObject(persona);
                    HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var request = httpClient.PostAsync("", content).GetAwaiter().GetResult();
                    string response = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Persona responseObj = JsonConvert.DeserializeObject<Persona>(response);
                    return responseObj;
                }
            }
            catch (Exception ex)
            {
                return persona = new Persona();
            }
        }

    }
}
