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
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                if ((_holder.Values[i].DateTime >= beginRange) && (_holder.Values[i].DateTime <= endRange))
                {
                    resultList.Add(_holder.Values[i]);
                }
            }
            return Ok(resultList);
        }

        [HttpPost]
        public IActionResult AddWeather([FromQuery]DateTime time, [FromQuery]int temp)
        {
            WeatherForecast weather = new WeatherForecast();
            weather.DateTime = time;
            weather.Temperature = temp;
            _holder.Values.Add(weather);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateWeather([FromQuery] DateTime timeToUpdate, [FromQuery] int newTemp)
        {
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                if (_holder.Values[i].DateTime == timeToUpdate)
                {
                    _holder.Values[i].Temperature = newTemp;
                }
            }
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteTempRange([FromQuery] DateTime beginRange, [FromQuery] DateTime endRange)
        {
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                if ((_holder.Values[i].DateTime < beginRange) || (_holder.Values[i].DateTime > endRange))
                {
                    resultList.Add(_holder.Values[i]);
                }
            }
            _holder.Values = resultList;
            return Ok();
        }
    }
}
