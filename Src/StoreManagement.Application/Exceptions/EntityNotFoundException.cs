using StoreManagement.Domain.Constants;

namespace StoreManagement.Application.Exceptions;

public class EntityNotFoundException(string message) : Exception(message)
{
    public string Title { get; } = ApiErrorTitle.EntityNotFound;
}