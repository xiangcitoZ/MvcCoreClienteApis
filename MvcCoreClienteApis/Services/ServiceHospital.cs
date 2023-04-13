using MvcCoreClienteApis.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace MvcCoreClienteApis.Services
{
    public class ServiceHospital
    {
        private MediaTypeWithQualityHeaderValue Header;

        private string UrlApi;
        public ServiceHospital()
        {
            this.UrlApi = "https://apicorehospitales2023xzx.azurewebsites.net/";
            this.Header =
                new MediaTypeWithQualityHeaderValue("application/json");

        }
        public async Task<List<Hospital>> GetHospitalsAsync()
        {   
            //SE UTILIZA EL OBJETO HttpClient PARA LAS PETICIONES
            using (HttpClient client = new HttpClient()) 
            {   
                //NECESITAMOS LA PETICION
                string request = "/api/hospitales";

                client.BaseAddress = new Uri(this.UrlApi);
                //COMO NORMA, DEBERIAMOS LIMPIAR LA CABECERAR
                //DE LA PETICION, POR SI CRUZAMOS PETICIONES
                client.DefaultRequestHeaders.Clear();
                //INDICAMOS EL TIPO DE DATOS QUE VAMOS A CONSUMIR
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                //REALIZAMOS UNA PETICION ASINCRONA AL METODO GET
                //Y NOS DEVOLVERA UNA RESPUESTA CON UN CODIGO DE LA PETICION
                HttpResponseMessage response =
                    await client.GetAsync(request);
                //DEBEMOS COMPROBAR LA RESPUESTA
                if(response.IsSuccessStatusCode) 
                {
                    //DENTRO DE RESPONSE TENEMOS UNA PROPIEDAD LLAMADA
                    //Content CON LOS DATOS
                    //PODEMOS DESERIALIZAR DIRECTAMENTE CON NUESTRAS
                    //CLASES SI SE LLAMAN IGUAL
                    List<Hospital> data = 
                        await response.Content.ReadAsAsync<List<Hospital>>();   
                    //SI NO SE LLAMASEN IGUAL, DEBO UTILIZAR [JsonProperty]
                    //TENDRIAMOS QUE DESCARGAR PRIMERO EL JSON Y DESPUES
                    //DESERIALIZAR CON JsonConvert

                    //string json = 
                    //    await response.Content.ReadAsStringAsync();
                    //List<Hospital> hospitals =
                    //    JsonConvert.DeserializeObject<List<Hospital>>(json);

                    return data;
                }
                else
                {
                    return null;
                }

            }
        }
        
    }
}
