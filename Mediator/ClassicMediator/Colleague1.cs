using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.ClassicMediator
{
    public class Colleague1 : Colleague
    {

        public Colleague1(Mediator mediator) : base (mediator)
        {

        }
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague 1 received notification a message: {message}");
        }
    }
}
