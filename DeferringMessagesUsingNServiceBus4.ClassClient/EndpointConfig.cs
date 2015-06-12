namespace DeferringMessagesUsingNServiceBus4.ClassClient
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With().DefaultBuilder();
        }
    }
}
