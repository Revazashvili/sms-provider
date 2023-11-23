namespace SmsProvider;

public class TwilioProvider : ISmsProvider
{
    public void Send(string to, string message)
    {
        Console.WriteLine("Sending sms with Twilio...");
    }
}