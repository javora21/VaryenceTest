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
        private IGoogleCoordinates _googleCoordinates;
        private IConfiguration _configuration;
        public GeocodingController(IGoogleCoordinates googleCoordinates,IConfiguration configuration)
        {
            _googleCoordinates = googleCoordinates;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> GetCoordinates([FromBody] PlaceFormModel model)
        {
            string key = _configuration["GeocodingApiKey"];
            string url = _configuration["GeocodingApiUrl"];

            CoordinatesDataModel data = await _googleCoordinates.GetCoordByPlace(model, key, url);
            if (data.Location == null)
            {
                data.Location = "Error";
                data.Latitude = "";
                data.Longitude = "";
            }
                            
           return Ok(data);
        }
    }
}