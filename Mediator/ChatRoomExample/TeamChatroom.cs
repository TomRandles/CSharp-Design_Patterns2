using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatorPattern.ChatRoomExample
{
    public class TeamChatRoom : Chatroom
    {

        private IList<TeamMember> teamMembers = new List<TeamMember>();

        public override void Register (TeamMember teamMember)
        {
            if (teamMember == null)
                throw new ArgumentNullException(nameof(teamMember));

            teamMember.SetChatRoom(this);
            teamMembers.Add(teamMember);
        }
        public void RegisterMembers (params TeamMember[] newTeamMembers)
        {
            foreach (var tm in newTeamMembers)
            {
                Register(tm);
            }
        }

        // Include the team  creation and registration together. Use generics
        public T CreateTeamMember<T>(string name) where T : TeamMember, new()
        {
            var teamMember = new T();
            teamMember.SetChatRoom(this);
            teamMembers.Add(teamMember);
            return teamMember;
        }

        public override void Send(string from, string message)
        {
            // Send message to all other team members
            foreach (var tm in teamMembers)
            {
                tm.Receive(from, message);
            }
        }

        public override void SendTo<T>(string from, string message)
        {
            var selectTeamMembers = teamMembers.OfType<T>().ToList();
            foreach (var tm in selectTeamMembers)
            {
                tm.Receive(from, message);
            }
        }
    }
}