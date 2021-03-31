using Proxy.PublicFacilitiesProxyExample;
using Proxy.VirtualProxyExample;
using System;
using System.Linq;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {

            // I. Proxy as secure gateway to object
            var secureCommunityCentre = new SecureCommunityCentreProxy(
                new CommunityCentre("Briar Hill community centre"));

            secureCommunityCentre.HasAccess("Mary Hannon");
            secureCommunityCentre.HasAccess("John Murphy");
            secureCommunityCentre.HasAccess("Mary Murphy");
            secureCommunityCentre.HasAccess("Mary O'Brien");
            secureCommunityCentre.HasAccess("John O'Sullivan");


            Console.WriteLine("\n\nVirtual Proxy examples");
            // II. Virtual proxy
            var expensiveObjectToLoad = ExpensiveToFullyLoad.Create();

            // Record of creation in history
            Console.WriteLine($"Record of expensive object creation: count: " +
                $"{expensiveObjectToLoad.History.Count}, entry: {expensiveObjectToLoad.History.Last()}");
            
            var list = expensiveObjectToLoad.HomeEntities;
            Console.WriteLine($"Record of object creation: count: " +
                $"{expensiveObjectToLoad.History.Count}, entry: {expensiveObjectToLoad.History.Last()}");

            var list2 = expensiveObjectToLoad.AwayEntities;
            Console.WriteLine($"Record of object creation: count: " +
                $"{expensiveObjectToLoad.History.Count}, entry: {expensiveObjectToLoad.History.Last()}");

            var list4  = expensiveObjectToLoad.HomeEntities;
            Console.WriteLine($"No expensive back-end access, already cached: count is the same: " +
                $"{expensiveObjectToLoad.History.Count}");

            // Lazy load
            var expensiveLazyLoad = new LazyExpensiveToFullyLoad();
            Console.WriteLine($"No expensive back-end access yet, history count only 1 for ctr, nothing for lazy loads: " +
                $"{expensiveLazyLoad.History.Count}, last entry : {expensiveLazyLoad.History.Last()}");



        }
    }
}
