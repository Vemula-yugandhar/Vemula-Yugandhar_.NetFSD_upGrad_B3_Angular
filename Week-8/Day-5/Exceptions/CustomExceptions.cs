// Base Exception (optional but clean)
public class AppException : Exception
{
    public AppException(string message) : base(message) { }
}

// 🔹 Not Found Exception
public class NotFoundException : AppException
{
    public NotFoundException(string message) : base(message) { }
}

// 🔹 Bad Request Exception
public class BadRequestException : AppException
{
    public BadRequestException(string message) : base(message) { }
}