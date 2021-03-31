using System;

namespace Proxy.PublicFacilitiesProxyExample
{
    public class CommunityCentre : IPublicFacility
    {
        public string FacilityName { get; }
        public CommunityCentre(string facilityName)
        {
            FacilityName = facilityName ?? throw new ArgumentNullException("No facility name given");
        }

        public bool HasAccess(string name)
        {
            System.Console.WriteLine($"{name} has access to the \"{FacilityName}\" community centre.");
            return true;
        }
    }
}
