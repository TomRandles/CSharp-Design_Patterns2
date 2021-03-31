using Proxy.PublicFacilitiesProxyExample;
using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var secureCommunityCentre = new SecureCommunityCentreProxy(
                new CommunityCentre("Briar Hill community centre"));

            secureCommunityCentre.HasAccess("Mary Hannon");
            secureCommunityCentre.HasAccess("John Murphy");
            secureCommunityCentre.HasAccess("Mary Murphy");
            secureCommunityCentre.HasAccess("Mary O'Brien");
            secureCommunityCentre.HasAccess("John O'Sullivan");
        }
    }
}
