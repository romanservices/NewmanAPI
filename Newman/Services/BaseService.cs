using Newman.EntityModels;

namespace Newman.Services
{
    public abstract class BaseService
    {
        protected readonly NewmanContext Context;
        protected BaseService(NewmanContext context)
        {
            Context =new NewmanContext(context.Options);
        }
    }
}
