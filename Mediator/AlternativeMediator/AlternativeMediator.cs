using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.ClassicMediator
{
    public abstract class Chatroom
    {
        public abstract void Register(AlternativeColleague colleague);
        public abstract void Send(string message, AlternativeColleague colleague);
    }
}
