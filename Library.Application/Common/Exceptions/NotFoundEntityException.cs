namespace Library.Application.Common.Exceptions
{
    public class NotFoundEntityException: Exception
    {
        public NotFoundEntityException(string name, object key): base($"Entity {name} with key {key} not found") {}
    }
}