using Geocoding.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geocoding.Services
{
    public interface IGoogleCoordinates
    {
        public Task<CoordinatesDataModel> GetCoordByPlace(PlaceFormModel model, string apiKey, string apiUrl);
    }
}
