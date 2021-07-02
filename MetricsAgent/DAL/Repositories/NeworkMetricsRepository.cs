using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsAgent.DAL.ConnectionMananagers;

namespace MetricsAgent.DAL.Repositories
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
        SQLiteConnectionManager _connectionManager;
        public NetworkMetricsRepository()
        {
            _connectionManager = new SQLiteConnectionManager();
        }
        public void Create(NetworkMetric item)
        {
            using var connection = _connectionManager.GetOpenedConnection();
            {
                connection.Open();
                using var cmd = new SQLiteCommand(connection);
                {
                    cmd.CommandText = "INSERT INTO networkmetrics(value, time) VALUES(@value, @time)";
                    cmd.Parameters.AddWithValue("@value", item.Value);
                    cmd.Parameters.AddWithValue("@time", item.Time);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<NetworkMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            using var connection = _connectionManager.GetOpenedConnection();
            {
                connection.Open();
                using var cmd = new SQLiteCommand(connection);
                {
                    cmd.CommandText = "SELECT * FROM networkmetrics WHERE time BETWEEN @fromTime AND @toTime";
                    cmd.Parameters.AddWithValue("@fromTime", fromTime);
                    cmd.Parameters.AddWithValue("@toTime", toTime);
                    cmd.Prepare();
                    var returnList = new List<NetworkMetric>();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        // пока есть что читать -- читаем
                        while (reader.Read())
                        {
                            // добавляем объект в список возврата
                            returnList.Add(new NetworkMetric
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
