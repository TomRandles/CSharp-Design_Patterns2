using System;

namespace MediatorPattern.ClassicMediator
{
    public class AltColleague4 : AlternativeColleague
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague 4 received notification message: {message}");
        }
    }
}
