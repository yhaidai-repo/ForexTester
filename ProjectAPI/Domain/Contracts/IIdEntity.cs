namespace Domain.Contracts;

public interface IIdEntity<T> 
{
    T Id { get; init; }
}
