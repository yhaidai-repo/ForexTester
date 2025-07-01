namespace Common.Exceptions;

public class EntityNotFoundException<T> : EntityNotFoundException
{
    public EntityNotFoundException(string id) : base($"Entity {typeof(T).Name} was not found by the specified ID: {id}")
    {
    }

    public EntityNotFoundException(int id) : base($"Entity {typeof(T).Name} was not found by the specified ID: {id}")
    {
    }
}

public class EntityNotFoundException(string message) : Exception(message);
