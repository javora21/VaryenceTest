using Geocoding.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geocoding.Services
{
    public interface IGoogleCoordinatesService
    {
        public Task<CoordinatesDataModel> GetCoordByPlace(PlaceFormModel model);
    }
}
