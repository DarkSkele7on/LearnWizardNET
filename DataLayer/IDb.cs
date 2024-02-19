using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDb<T, TK> where TK : IConvertible
    {
        Task CreateAsync(T item);

        Task<T> ReadAsync(TK key, bool useNavigationalProperties = false, bool isReadOnly = true);

        Task<ICollection<T>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true);

        Task UpdateAsync(T item, bool useNavigationalProperties = false, bool isReadOnly = true);

        Task DeleteAsync(TK key);
    }
}
