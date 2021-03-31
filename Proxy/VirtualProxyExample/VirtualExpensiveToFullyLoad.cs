using System.Collections.Generic;

namespace Proxy.VirtualProxyExample
{
    public class VirtualExpensiveToFullyLoad : ExpensiveToFullyLoad
    {
        public override IEnumerable<ExpensiveEntity> AwayEntities
        {
            // Only fetch the expensive resource if it has not been loaded previously
            // NB: not thread safe!
            get
            {
                if (base.AwayEntities == null)
                {
                    base.AwayEntities = ExpensiveDataSource.GetEntities(this); 
                }
                return base.AwayEntities;
            }
            protected set => base.AwayEntities = value; 
        }
        public override IEnumerable<ExpensiveEntity> HomeEntities
        {
            get
            {
                if (base.HomeEntities == null)
                {
                    base.HomeEntities = ExpensiveDataSource.GetEntities(this);
                }
                return base.HomeEntities;
            }
            protected set => base.HomeEntities = value;
        }
    }
}