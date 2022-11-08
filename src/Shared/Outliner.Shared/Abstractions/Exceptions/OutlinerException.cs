namespace Outliner.Shared.Abstractions.Exceptions;

public class OutlinerException : Exception
{
    public OutlinerException(string message): base(message)
    { }
}