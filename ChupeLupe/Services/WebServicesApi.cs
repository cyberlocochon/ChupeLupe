using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChupeLupe.Models;
using ChupeLupe.Services;
using FireSharp;
using FireSharp.Config;
using FireSharp.Extensions;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebServicesApi))]

namespace ChupeLupe.Services
{
        public class WebServicesApi : IWebServicesApi
    {
        const string _baseUrl = "https://chupelupe-f5770.firebaseio.com/";
        const string _authSecret = "WdzgjFZq1Xoqw53vcBK9AoGlhpSdRSUjGAn9aUDO"; //Cuentas de Servicio/Secretos de la BD   
        public IFirebaseClient Client { get; set; }

        public WebServicesApi()
        {
            if (Client == null)
            {
                IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = _authSecret,
                    BasePath = _baseUrl
                };
                Client = new FirebaseClient(config);
            }
        }


        public async Task<List<Promotion>> GetPromotions()
        {
            List<Promotion> promotions = new List<Promotion>();

            try
            {
               FirebaseResponse response = await Client.GetAsync("promotions");

                if (response == null)
                {
                    return promotions;
                }
                if (string.IsNullOrEmpty(response.Body))
                {
                    return promotions;
                }

                var jsonResponse = response.Body;
                var jsonObject = JObject.Parse(jsonResponse);

                foreach (var item in jsonObject)
                {
                    var promotion = await Task.Run(() =>
                    JsonConvert.DeserializeObject<Promotion>(item.Value.ToJson()));
                    if (promotion == null)
                    {
                        continue;
                    }
                    promotions.Add(promotion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return promotions;
        }
    }
}
