using System;
using System.Threading.Tasks;

namespace FootballLeague.Data.Common
{
    public interface IDbQueryRunner : IDisposable
    {
        Task RunQueryAsync(string query, params object[] parameters);
    }
}
