using System;

namespace MediatorPattern.ChatRoomExample
{
    public class Developer : TeamMember
    {
        public Developer(string name) : base (name)
        {}
        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{Name} ({nameof(Developer)}) received: ");
            base.Receive(from, message);
        }

        public void SendToTesters(string message)
        {
            base.chatroom.SendTo<Tester>(Name, message);
        }
    }
}