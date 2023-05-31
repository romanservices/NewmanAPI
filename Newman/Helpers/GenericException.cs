namespace Newman.Helpers
{
    public class GenericException : Exception
    {
        public GenericException(string message) : base($"{message}") { }
    }
    public class NotFoundException : Exception
    {
        public NotFoundException(int id, Type type) : base($"{type.Name} with the id of {id} was not found") { }
        public static void Check<T>(T t, int id)
        {
            if (t == null)
            {
                throw new NotFoundException(id, typeof(T));
            }
        }
    }
}
