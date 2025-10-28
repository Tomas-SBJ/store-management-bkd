namespace StoreManagement.Application.Exceptions;

public class EntityAlreadyExistsException(string message) : Exception(message);