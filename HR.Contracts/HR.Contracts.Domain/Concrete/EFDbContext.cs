using System.Data.Entity;
using HR.Contracts.Domain.Entities;

namespace HR.Contracts.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public IDbSet<Contract> Contracts { get; set; }
    }
}