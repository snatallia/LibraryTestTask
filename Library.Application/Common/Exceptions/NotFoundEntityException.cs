namespace Library.Application.Common.Exceptions
{
    public class NotFoundEntityException: Exception
    {
        public NotFoundEntityException(string name, string fieldname, object key): base($"Entity {name} with field {fieldname} = {key} not found") {}
    }
}