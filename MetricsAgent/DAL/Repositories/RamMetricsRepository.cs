using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsAgent.DAL.ConnectionMananagers;

namespace MetricsAgent.DAL.Repositories
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        SQLiteConnectionManager _connectionManager;
        public RamMetricsRepository()
        {
            _connectionManager = new SQLiteConnectionManager();
        }
        public void Create(RamMetric item)
        {
            using var connection = _connectionManager.GetOpenedConnection();
            {
                connection.Open();
                using var cmd = new SQLiteCommand(connection);
                {
                    cmd.CommandText = "INSERT INTO rammetrics(value, time) VALUES(@value, @time)";
                    cmd.Parameters.AddWithValue("@value", item.Value);
                    cmd.Parameters.AddWithValue("@time", item.Time);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<RamMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = _connectionManager.GetOpenedConnection();
            {
                connection.Open();
                using var cmd = new SQLiteCommand(connection);
                {
                    cmd.CommandText = "SELECT * FROM rammetrics WHERE time BETWEEN @fromTime AND @toTime";
                    cmd.Parameters.AddWithValue("@fromTime", fromTime);
                    cmd.Parameters.AddWithValue("@toTime", toTime);
                    cmd.Prepare();
                    var returnList = new List<RamMetric>();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        // пока есть что читать -- читаем
                        while (reader.Read())
                        {
                            // добавляем объект в список возврата
                            returnList.Add(new RamMetric
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
