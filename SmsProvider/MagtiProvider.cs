namespace SmsProvider;

public class MagtiProvider : ISmsProvider
{
    public void Send(string to, string message)
    {
        Console.WriteLine("Sending sms with Magti...");
    }
}