using System;
using DeferringMessagesUsingNServiceBus4.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace DeferringMessagesUsingNServiceBus4
{
    public class DeferMessagesUntilWebServiceImplementationIsReady : IHandleMessages<MessageIWantToDefer>
    {
        private readonly IBus bus;
        private static readonly ILog Log = LogManager.GetLogger(typeof(DeferMessagesUntilWebServiceImplementationIsReady));

        public DeferMessagesUntilWebServiceImplementationIsReady(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(MessageIWantToDefer message)
        {
            //changing the TimeSpan here from one hour to one minute for the sake of the example
            Log.Warn("Handling MessageIWantToDefer and deferring it for one minute.");
            bus.Defer(new TimeSpan(0, 0, 1, 0), message);
            bus.DoNotContinueDispatchingCurrentMessageToHandlers();
        }
    }

    public class DeferMessagesUntilWebServiceImplementationIsReadyConfiguration : ISpecifyMessageHandlerOrdering
    {
        public void SpecifyOrder(Order order)
        {
            order.SpecifyFirst<MessageIWantToDefer>();
        }
    }
}
