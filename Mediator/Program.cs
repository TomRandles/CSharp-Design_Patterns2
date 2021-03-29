using MediatorPattern.ClassicMediator;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // classic GoF mediator pattern
            var mediator = new ConcreteMediator();
            var colleague1 = new Colleague1(mediator);
            var colleague2 = new Colleague2(mediator);
            mediator.Colleague1 = colleague1;
            mediator.Colleague2 = colleague2;

            colleague1.Send("Hello there from colleague 1");
            colleague2.Send("Hi there from colleague 2");


            // Alternative and more flexible Mediator 
            var flexibleMediator = new AltConcreteMediator();
            var colleague3 = new AltColleague3();
            flexibleMediator.Register(colleague3);
            var colleague4 = new AltColleague4();
            flexibleMediator.Register(colleague4);


            colleague3.Send("Hello there from colleague 3");
            colleague4.Send("Hi there from colleague 4");
        }
    }
}
