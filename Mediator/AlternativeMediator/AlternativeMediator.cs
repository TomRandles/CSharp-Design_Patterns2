using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.ClassicMediator
{
    public abstract class AlternativeMediator
    {
        public abstract void Send(string message, AlternativeColleague colleague);
    }
}
