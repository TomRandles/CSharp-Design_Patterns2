using System.Collections.Generic;

namespace Proxy.VirtualProxyExample
{
    public static class ExpensiveDataSource
    {
        public static IList<ExpensiveEntity> GetEntities(BaseClassWithHistory owner)
        {
            var list = new List<ExpensiveEntity>();
            for (int i =0; i<10; i++)
            {
                list.Add(new ExpensiveEntity { Id = i });
            }
            owner.History.Add("Got expensive resources from source");
            return list;
        }
    }
}
