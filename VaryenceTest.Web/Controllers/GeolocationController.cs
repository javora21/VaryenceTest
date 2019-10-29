using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Geocoding.Services;
using Geocoding.Data.Models;
using Microsoft.Extensions.Configuration;

namespace VaryenceTest.Web.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GeocodingController : ControllerBase
    {
        private IGoogleCoordinatesService _googleCoordinates;
        private IConfiguration _configuration;
        public GeocodingController(IGoogleCoordinatesService googleCoordinates,IConfiguration configuration)
        {
            _googleCoordinates = googleCoordinates;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> GetCoordinates([FromBody] PlaceFormModel model)
        {
            CoordinatesDataModel data = await _googleCoordinates.GetCoordByPlace(model);
            if (data.Location == null)
            {
                data.Location = "Error";
                data.Latitude = 0;
                data.Longitude = 0;
            }
                            
           return Ok(data);
        }
    }
}