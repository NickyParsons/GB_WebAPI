using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsAgent.DAL.ConnectionMananagers;

namespace MetricsAgent.DAL.Repositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        SQLiteConnectionManager _connectionManager;
        public CpuMetricsRepository()
        {
            _connectionManager = new SQLiteConnectionManager();
        }
        public void Create(CpuMetric item)
        {
            using var connection = _connectionManager.GetOpenedConnection();
            {
                using var cmd = new SQLiteCommand(connection);
                {
                    cmd.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(@value, @time)";
                    cmd.Parameters.AddWithValue("@value", item.Value);
                    cmd.Parameters.AddWithValue("@time", item.Time);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<CpuMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = _connectionManager.GetOpenedConnection();
            {
                using var cmd = new SQLiteCommand(connection);
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM cpumetrics WHERE time BETWEEN @fromTime AND @toTime";
                    cmd.Parameters.AddWithValue("@fromTime", fromTime);
                    cmd.Parameters.AddWithValue("@toTime", toTime);
                    cmd.Prepare();
                    var returnList = new List<CpuMetric>();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        // пока есть что читать -- читаем
                        while (reader.Read())
                        {
                            // добавляем объект в список возврата
                            returnList.Add(new CpuMetric
                            {
                                Id = reader.GetInt32(0),
                                Value = reader.GetInt32(1),
                                Time = reader.GetInt32(2)
                            });
                        }
                    }
                    return returnList;
                }
            }
        }
    }
}
