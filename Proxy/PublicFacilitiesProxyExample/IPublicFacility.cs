namespace Proxy.PublicFacilitiesProxyExample
{
    public interface IPublicFacility
    {
        public string FacilityName { get; }
        bool HasAccess(string name);
    }
}