using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.VirtualProxyExample
{
    public class ExpensiveToFullyLoad : BaseClassWithHistory
    {
        // Sepcify the virtual proxy to be used rather than the type itself
        // Factory method pattern. 
        public static ExpensiveToFullyLoad Create()
        {
            return new VirtualExpensiveToFullyLoad();
        }

        // Both are virtual - may not always need.
        // Only want to fetch when we need them
        public virtual IEnumerable<ExpensiveEntity> HomeEntities { get; protected set; }

        public virtual IEnumerable<ExpensiveEntity> AwayEntities { get; protected set; }

        // Ctor can only be called by class or derived children
        // Control how we get access to this instance. We can inject in our proxy type.
        protected ExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
        }
    }
}
