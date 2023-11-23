namespace SmsProvider;

public class RandomSmsProviderSelector : ISmsProviderSelector
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Random _random;

    public RandomSmsProviderSelector(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _random = new Random();
    }
    
    public ISmsProvider Select()
    {
        var smsProviders = _serviceProvider
            .GetServices<ISmsProvider>()
            .ToArray();
        
        var randomElementIndex = _random.Next(smsProviders.Length);
        return smsProviders[randomElementIndex];
    }
}