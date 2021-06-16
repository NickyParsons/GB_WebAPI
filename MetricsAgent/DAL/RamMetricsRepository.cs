using MetricsAgent.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public void Create(RamMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
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
            using var connection = new SQLiteConnection(ConnectionString);
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
