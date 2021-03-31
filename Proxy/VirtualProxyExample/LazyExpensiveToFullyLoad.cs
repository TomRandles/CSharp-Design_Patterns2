using System;
using System.Collections.Generic;

namespace Proxy.VirtualProxyExample
{
    public class LazyExpensiveToFullyLoad : BaseClassWithHistory
    {
        private Lazy<IEnumerable<ExpensiveEntity>> _homeEntities;

        public IEnumerable<ExpensiveEntity> HomeEntities
        {
            get
            {
                return _homeEntities.Value;
            }
        }
        private Lazy<IEnumerable<ExpensiveEntity>> _awayEntities;

        public IEnumerable<ExpensiveEntity> AwayEntities
        {
            get
            {
                return _awayEntities.Value;
            }
        }

        // Data populated by constructor. Lazy<T> - don't actually make the calls to the expensive data source until
        // something tries to access them.
        public LazyExpensiveToFullyLoad()
        {
            History.Add("LazyExpensiveToFullyLoad constructor called.");
            _homeEntities = new Lazy<IEnumerable<ExpensiveEntity>>(() => ExpensiveDataSource.GetEntities(this));

            _awayEntities = new Lazy<IEnumerable<ExpensiveEntity>>(() => ExpensiveDataSource.GetEntities(this));
        }
    }
}
