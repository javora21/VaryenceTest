using System;
using System.Collections.Generic;
using System.Text;
using Geocoding.Data.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Geocoding.Services
{
    public class GoogleCoordinates : IGoogleCoordinates
    {
        public async Task<CoordinatesDataModel> GetCoordByPlace(PlaceFormModel model, string apiKey, string apiUrl)
        {
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
                        dataModel.Latitude = JsonConvert.DeserializeObject<dynamic>(data).results[0].geometry.location.lat.ToString();
                        dataModel.Longitude = JsonConvert.DeserializeObject<dynamic>(data).results[0].geometry.location.lng.ToString();
                        dataModel.Location = JsonConvert.DeserializeObject<dynamic>(data).results[0].formatted_address.ToString();

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
