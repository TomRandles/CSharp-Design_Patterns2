using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatorPattern.ClassicMediator
{
    public class AltConcreteMediator : Chatroom
    {

        private IList<AlternativeColleague> colleagues = new List<AlternativeColleague>();

        public override void Register (AlternativeColleague colleague)
        {
            if (colleague == null)
                throw new ArgumentNullException(nameof(colleague));

            colleague.SetMediator(this);
            colleagues.Add(colleague);
        }

        // Include the colleague creation and registration together. Use generics
        public T CreateColleague<T>() where T : AlternativeColleague, new()
        {
            var colleague = new T();
            colleague.SetMediator(this);
            colleagues.Add(colleague);
            return colleague;
        }

        public override void Send(string message, AlternativeColleague colleague)
        {
            if (colleague == null)
                throw new ArgumentNullException(nameof(colleague));

            // Send notification to all other colleagues
            colleagues.Where(c => c != colleague).ToList().ForEach(c => c.HandleNotification(message));
        }
    }
}