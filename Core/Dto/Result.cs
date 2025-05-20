namespace Core.Dto;

public class Result<T>
{
    public T? Value { get; init; }
    public string? Error { get; init; }

    public bool IsSuccessful => string.IsNullOrWhiteSpace(Error);
}

public class Result : Result<string> { }
