using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatorPattern.ClassicMediator
{
    public class AltConcreteMediator : AlternativeMediator
    {

        private IList<AlternativeColleague> colleagues = new List<AlternativeColleague>();

        public void Register (AlternativeColleague colleague)
        {
            if (colleague == null)
                throw new ArgumentNullException(nameof(colleague));

            colleague.SetMediator(this);
            colleagues.Add(colleague);
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