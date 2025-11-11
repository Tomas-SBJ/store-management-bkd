using StoreManagement.Domain.Constants;

namespace StoreManagement.Application.Exceptions;

public class EntityAlreadyExistsException(string message) : Exception(message)
{
    public string Title { get; } = ApiErrorTitle.EntityAlreadyExists;
}