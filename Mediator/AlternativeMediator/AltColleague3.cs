using System;

namespace MediatorPattern.ClassicMediator
{
    public class AltColleague3 : AlternativeColleague
    {

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague 3 received notification a message: {message}");
        }
    }
}
