using System.Data.Entity;


namespace Common.Data
{
    public class BaseDbContext: DbContext
    {
        public BaseDbContext(string nameOrConnectionString):base(nameOrConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
