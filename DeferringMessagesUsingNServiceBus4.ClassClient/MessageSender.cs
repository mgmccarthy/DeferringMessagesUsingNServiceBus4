using System;
using DeferringMessagesUsingNServiceBus4.Messages;
using NServiceBus;

namespace DeferringMessagesUsingNServiceBus4.ClassClient
{
    public class MessageSender : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("Press 'Enter' to send MessageIWantToDefer");

            while (Console.ReadLine() != null)
            {
                Bus.Send(new MessageIWantToDefer());
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
