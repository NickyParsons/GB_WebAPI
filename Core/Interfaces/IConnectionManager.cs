using System.Data;

namespace Core.Interfaces
{
    public interface IConnectionManager
    {
        public IDbConnection GetOpenedConnection();
        public void CreateOpenedConnection();
    }
}
