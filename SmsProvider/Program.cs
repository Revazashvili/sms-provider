using SmsProvider;

var serviceCollection = new ServiceCollection()
    .AddScoped<ISmsProvider,MagtiProvider>()
    .AddScoped<ISmsProvider,GeoCellProvider>()
    .AddScoped<ISmsProvider,TwilioProvider>();

var serviceProvider = serviceCollection.BuildServiceProvider();

Console.WriteLine("Supported provider selectors: Random,Percent");
Console.WriteLine("Choose provider selector by typing name");
var selector = Console.ReadLine()?.ToLower();
if (string.IsNullOrEmpty(selector))
    throw new Exception("selector value must not be null or empty");

ISmsProviderSelector smsProviderSelector = null;
if (selector == "random")
    smsProviderSelector = new RandomSmsProviderSelector(serviceProvider);
else if (selector == "percent")
{
    var smsProviderPercentages = new Dictionary<int, ISmsProvider>();
    int percent;
    foreach (var provider in new ISmsProvider[] {new MagtiProvider(),new GeoCellProvider(),new TwilioProvider()})
    {
        Console.WriteLine($"Enter percentage for Provider: {provider.GetType().Name}");
        percent = Convert.ToInt32(Console.ReadLine());
        smsProviderPercentages.Add(percent,provider);
    }

    smsProviderSelector = new PercentSmsProviderSelector(smsProviderPercentages, serviceProvider);
}

var smsProvider = smsProviderSelector!.Select();
smsProvider.Send("555123456","test message");
