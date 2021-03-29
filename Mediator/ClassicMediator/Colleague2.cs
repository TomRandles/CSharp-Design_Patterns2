using System;

namespace MediatorPattern.ClassicMediator
{
    public class Colleague2 : Colleague
    {

        public Colleague2(Mediator mediator) : base(mediator)
        {

        }
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague 2 received notification a message: {message}");
        }
    }
}
