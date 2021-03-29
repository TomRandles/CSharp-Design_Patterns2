using System;

namespace MediatorPattern.ChatRoomExample
{
    public class Tester : TeamMember
    {
        public Tester(string name) : base (name)
        {}
        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{Name} ({nameof(Tester)}) received message: ");
            base.Receive(from, message);
        }
        public void SendToDevelopers(string message)
        {
            base.chatroom.SendTo<Developer>(Name, message);
        }
    }
}