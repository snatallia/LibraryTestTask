namespace Library.Application.Common.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(string name, string fieldname, object key): base($"Entity {name} with field {fieldname} = {key} not found") {}
    }
}