using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1
{
    public class WeatherForecastHolder
    {
        public List<WeatherForecast> Values { get; set; }
        public WeatherForecastHolder()
        {
            Values = new List<WeatherForecast>();
        }
    }
}
