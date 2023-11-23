namespace SmsProvider;

public class PercentSmsProviderSelector : ISmsProviderSelector
{
    private readonly Dictionary<int, ISmsProvider> _smsProvidersPercentage;
    private readonly IServiceProvider _serviceProvider;
    private readonly Random _random;

    public PercentSmsProviderSelector(Dictionary<int, ISmsProvider> smsProvidersPercentage,
        IServiceProvider serviceProvider)
    {
        _smsProvidersPercentage = smsProvidersPercentage;
        _serviceProvider = serviceProvider;
        _random = new Random();
    }

    public ISmsProvider Select()
    {
        var randomPercent = _random.Next(100);
        var percent = _smsProvidersPercentage.Keys.Min(i => (Math.Abs(randomPercent - i),i)).i;

        var exists = _smsProvidersPercentage.TryGetValue(percent, out var provider);
        if (!exists)
            throw new Exception("Can't find provider with this percentage");

        return _serviceProvider
            .GetServices<ISmsProvider>()
            .FirstOrDefault(smsProvider => smsProvider.GetType() == provider.GetType());
    }
}