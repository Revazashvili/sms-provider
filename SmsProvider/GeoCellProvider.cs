namespace SmsProvider;

public class GeoCellProvider : ISmsProvider
{
    public void Send(string to, string message)
    {
        Console.WriteLine("Sending sms with GeoCell...");
    }
}