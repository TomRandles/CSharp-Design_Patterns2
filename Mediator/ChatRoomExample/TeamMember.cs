using System;

namespace MediatorPattern.ChatRoomExample
{
    public abstract class TeamMember
    {
        protected Chatroom chatroom;

        public string Name { get; }

        public TeamMember(string name)
        {
            this.Name = name;
        }

        // Set the team member mediator - chatroom
        internal void SetChatRoom(Chatroom chatroom)
        {
            this.chatroom = chatroom ?? throw new ArgumentNullException(nameof(chatroom));
        }
        public void Send (string message)
        {
            chatroom.Send(this.Name, message);
        }
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"From {from}, message: {message}");
        }
    }
}