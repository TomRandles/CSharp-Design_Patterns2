using System;

namespace MediatorPattern.ClassicMediator
{
    public class ConcreteMediator : Mediator
    {
        // The references to the two colleagues works, but is rigid and doesn't scale
        public Colleague1 Colleague1 { get; set; }
        public Colleague2 Colleague2 { get; set; }
        public override void Send(string message, Colleague colleague)
        {
            if (colleague == null)
                throw new ArgumentNullException(nameof(colleague));

            if (colleague == this.Colleague1)
            {
                System.Console.WriteLine($"Mediator: Send message {message} to colleague 2");
                Colleague2.HandleNotification(message);
            }
            else
            {
                System.Console.WriteLine($"Send message {message} to colleague 1");
                Colleague1.HandleNotification(message);
            }
        }
    }
}