using System.Threading.Tasks;
using Dvchevskii.Optional.Async;
using Dvchevskii.Optional.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Dvchevskii.Optional.EntityFrameworkCore
{
    public static class DbSetExtensions
    {
        public static Option<T> FindOrNone<T>(this DbSet<T> set, params object[] keyValues)
            where T : class => set.Find(keyValues).AsOption();

        public static Task<Option<T>> FindOrNoneAsync<T>(this DbSet<T> set, params object[] keyValues)
            where T : class => set.FindAsync(keyValues).AsTask().AsOptionAsync();
    }
}
