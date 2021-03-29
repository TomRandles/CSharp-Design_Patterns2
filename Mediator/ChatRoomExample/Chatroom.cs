namespace MediatorPattern.ChatRoomExample
{
    public abstract class Chatroom
    {
        public abstract void Register(TeamMember teamMember);
        public abstract void Send(string from, string message);
        public abstract void SendTo<T>(string from, string message) where T : TeamMember;
    }
}
