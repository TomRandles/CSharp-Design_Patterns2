using System.Collections.Generic;

namespace Proxy.VirtualProxyExample
{
    public class BaseClassWithHistory
    {
        public IList<string> History { get; set; } = new List<string>();
    }
}