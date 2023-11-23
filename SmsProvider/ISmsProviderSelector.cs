namespace SmsProvider;

public interface ISmsProviderSelector
{
    ISmsProvider Select();
}