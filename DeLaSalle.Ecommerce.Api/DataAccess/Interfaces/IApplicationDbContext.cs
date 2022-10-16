using System.Data.Common;

namespace DeLaSalle.Ecommerce.Api.DataAccess.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbConnection Connection { get; }
    }
}
