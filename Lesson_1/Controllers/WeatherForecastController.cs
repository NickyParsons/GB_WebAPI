using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        WeatherForecastHolder _holder;

        public WeatherForecastController(WeatherForecastHolder holder)
        {
            _holder = holder;
        }

        [HttpGet]
        public IActionResult GetTempRange([FromQuery] DateTime beginRange, [FromQuery] DateTime endRange)
        {
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            foreach (WeatherForecast weather in _holder.Values)
            {
                if ((weather.DateTime >= beginRange) && (weather.DateTime <= endRange))
                {
                    resultList.Add(weather);
                }
            }
            return Ok(resultList);
        }

        [HttpPost]
        public IActionResult AddWeather([FromQuery]DateTime time, [FromQuery]int temperature)
        {
            WeatherForecast weather = new WeatherForecast();
            weather.DateTime = time;
            weather.Temperature = temperature;
            _holder.Values.Add(weather);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateWeather([FromQuery] DateTime timeToUpdate, [FromQuery] int newTemperature)
        {
            foreach (WeatherForecast weather in _holder.Values)
            {
                if (weather.DateTime == timeToUpdate)
                {
                    weather.Temperature = newTemperature;
                }
            }
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteTempRange([FromQuery] DateTime beginRange, [FromQuery] DateTime endRange)
        {
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            foreach (WeatherForecast weather in _holder.Values)
            {
                if ((weather.DateTime < beginRange) || (weather.DateTime > endRange))
                {
                    resultList.Add(weather);
                }
            }
            _holder.Values = resultList;
            return Ok();
        }
    }
}
