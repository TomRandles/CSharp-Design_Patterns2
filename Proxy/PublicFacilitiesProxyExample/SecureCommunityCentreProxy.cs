namespace Proxy.PublicFacilitiesProxyExample
{
    public class SecureCommunityCentreProxy : IPublicFacility
    {
        private readonly IPublicFacility communityCentre;

        public string FacilityName { get; }

        public SecureCommunityCentreProxy(IPublicFacility communityCentre)
        {
            this.communityCentre = communityCentre;
            this.FacilityName = communityCentre.FacilityName;
        }
        public bool HasAccess(string name)
        {
            if (name == "John O'Sullivan")
            {
                this.communityCentre.HasAccess(name);
                return true;
            }
            else
            {
                System.Console.WriteLine($"{name} does not have access to the \"{FacilityName}\" community centre.");
                return false;
            }
        }
    }
}