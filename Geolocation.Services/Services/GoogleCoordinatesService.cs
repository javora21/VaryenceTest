using System;
using System.Collections.Generic;
using System.Text;
using Geocoding.Data.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Geocoding.Services
{
    public class GoogleCoordinatesService : IGoogleCoordinatesService
    {
        IConfiguration _configuration;
        public GoogleCoordinatesService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<CoordinatesDataModel> GetCoordByPlace(PlaceFormModel model)
        {
            string apiUrl = _configuration["GeocodingApiUrl"];
            string apiKey = _configuration["GeocodingApiKey"];
            try
            {
                string url = $"{apiUrl}?address={model.Place}" + (string.IsNullOrEmpty(model.City) ? "" : $"+{model.City}") + $"&key={apiKey}";

                string data;
                var dataModel = new CoordinatesDataModel();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse resp = await request.GetResponseAsync();
                HttpWebResponse response = (HttpWebResponse)resp;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            data = reader.ReadToEnd();
                        }
                    }
                    if (JsonConvert.DeserializeObject<dynamic>(data).status == "OK")
                    {
                        string lat = JsonConvert.DeserializeObject<dynamic>(data).results[0].geometry.location.lat.ToString();
                        string lng = JsonConvert.DeserializeObject<dynamic>(data).results[0].geometry.location.lng.ToString();
                        dataModel.Location = JsonConvert.DeserializeObject<dynamic>(data).results[0].formatted_address.ToString();
                        dataModel.Latitude = double.Parse(lat);
                        dataModel.Longitude = double.Parse(lng);
                    }
                }
                response.Close();

                return dataModel;
            }
            catch
            {
                return new CoordinatesDataModel();
            }

        }
    }
}
