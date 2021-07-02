using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.DAL.Models;
using MetricsAgent.Responses;

namespace MetricsAgent.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>().ForMember("Time", opt => opt.MapFrom(c => DateTimeOffset.FromUnixTimeSeconds(c.Time)));
            CreateMap<RamMetric, RamMetricDto>().ForMember("Time", opt => opt.MapFrom(c => DateTimeOffset.FromUnixTimeSeconds(c.Time)));
            CreateMap<HddMetric, HddMetricDto>().ForMember("Time", opt => opt.MapFrom(c => DateTimeOffset.FromUnixTimeSeconds(c.Time)));
            CreateMap<NetworkMetric, NetworkMetricDto>().ForMember("Time", opt => opt.MapFrom(c => DateTimeOffset.FromUnixTimeSeconds(c.Time)));
            CreateMap<DotNetMetric, DotNetMetricDto>().ForMember("Time", opt => opt.MapFrom(c => DateTimeOffset.FromUnixTimeSeconds(c.Time)));
        }
    }
}
