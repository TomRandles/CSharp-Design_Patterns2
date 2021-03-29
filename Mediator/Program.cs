using MediatorPattern.ChatRoomExample;
using MediatorPattern.ClassicMediator;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Classic mediator pattern");
            // I. classic GoF mediator pattern
            var mediator = new ConcreteMediator();
            var colleague1 = new Colleague1(mediator);
            var colleague2 = new Colleague2(mediator);
            mediator.Colleague1 = colleague1;
            mediator.Colleague2 = colleague2;

            colleague1.Send("Hello there from colleague 1");
            colleague2.Send("Hi there from colleague 2");

            System.Console.WriteLine("");
            System.Console.WriteLine("Alternative and more flexible mediator");

            // II. Alternative and more flexible Mediator 
            var flexibleMediator = new AltConcreteMediator();
            //var colleague3 = new AltColleague3();
            //flexibleMediator.Register(colleague3);
            //var colleague4 = new AltColleague4();
            //flexibleMediator.Register(colleague4);

            // More efficient approach, only two lines of code
            var colleague3 = flexibleMediator.CreateColleague<AltColleague3>();
            var colleague4 = flexibleMediator.CreateColleague<AltColleague4>();

            colleague3.Send("Hello there from colleague 3");
            colleague4.Send("Hi there from colleague 4");

            System.Console.WriteLine("");
            System.Console.WriteLine("Chatroom example using mediator pattern");

            // Create mediator - chatroom
            var chatroom = new TeamChatRoom();

            // Create some team members
            var dave = new Developer("Dave");
            var harry = new Developer("Harry");
            var jane = new Developer("Jane");

            var chloe = new Tester("Chloe");
            var jack = new Tester("Jack");

            chatroom.RegisterMembers(dave, harry, jane, chloe, jack);

            chloe.Send("Hello there from testing. No bugs today!!");
            dave.Send("Hello from development. That is because of the quality code you're getting!");

            // Send message only to developers
            jack.SendToDevelopers("Testing not going too good today folks :-(");

            harry.SendToTesters("Yawn, testers are always complaining.");

        }
    }
}
