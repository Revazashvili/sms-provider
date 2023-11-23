namespace SmsProvider;

public interface ISmsProvider
{
    void Send(string to, string message);
}