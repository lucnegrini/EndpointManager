using EndpointManager.Models;
using EndpointManager.Services;

namespace EndpointManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // I was gonna use Autofac to manage the dependencies and create a singleton instance of Company
            // where the endpoints are stored but for a simpler solution this will do the trick
            var menuService = new MenuService(new CompanyService(new Company()), new EndpointService());

            menuService.ShowMenu();
        }
    }
}
