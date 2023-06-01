using Newman.EntityModels;

namespace Newman.Services
{
    public abstract class BaseService
    {
        protected readonly SqlLiteDbContext Context;
        protected BaseService(SqlLiteDbContext context)
        {
            Context =new SqlLiteDbContext(context.Options);
        }
    }
}
