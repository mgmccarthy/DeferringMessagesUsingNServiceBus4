using DeferringMessagesUsingNServiceBus4.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace DeferringMessagesUsingNServiceBus4
{
    public class IAlsoHandleMessageIWantToDeferButIWillNeverHandleItAsLongAsItsDeferred : IHandleMessages<MessageIWantToDefer>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(IAlsoHandleMessageIWantToDeferButIWillNeverHandleItAsLongAsItsDeferred));

        public void Handle(MessageIWantToDefer message)
        {
            //MessageIWantToDefer should never get to this 
            Log.Warn("If you're reading this, then something has gone very wrong.");
        }
    }
}
