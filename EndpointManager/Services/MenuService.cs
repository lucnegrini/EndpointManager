using EndpointManager.Abstractions;
using EndpointManager.Enums;
using EndpointManager.Extensions;
using EndpointManager.Helpers;
using EndpointManager.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

//This would allow for this class to be tested
[assembly: InternalsVisibleTo("EndpointManager.Tests")]
namespace EndpointManager.Services
{
    public class MenuService : IMenuService
    {
        private ICompanyService CompanyService { get; set; }
        private IEndpointService EndpointService { get; set; }
        public MenuService(ICompanyService companyService, IEndpointService endpointService)
        {
            this.CompanyService = companyService;
            this.EndpointService = endpointService;
        }


        public void ShowMenu()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("******Welcome to Endpoint Manager******");
            Console.WriteLine("***************************************");
            Console.WriteLine();

            var exit = false;

            while (!exit)
            {
                //Dislay all menu options and get valid user input;
                MenuHelper.WriteOptions<MainMenuEnum>("Please select one of the options below:");
                MainMenuEnum selected = MenuHelper.GetResponse<MainMenuEnum>();

                switch (selected)
                {
                    case MainMenuEnum.InsertEndpoint:
                        this.InsertEndpoint();
                        break;
                    case MainMenuEnum.EditEndpoint:
                        this.EditEndpoint();
                        break;
                    case MainMenuEnum.DeleteEndpoint:
                        this.DeleteEndpoint();
                        break;
                    case MainMenuEnum.ListEndpoints:
                        this.ListEndpoints();
                        break;
                    case MainMenuEnum.FindEndpoint:
                        this.FindEndpoint();
                        break;
                    case MainMenuEnum.Exit:
                        exit = this.ConfirmExit();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Thank you for using Endpoint Manager! Good bye!");
            Console.WriteLine("***********************************************");
            Console.WriteLine();
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }

        internal bool ConfirmExit()
        {
            MenuHelper.WriteOptions<ExitMenuEnum>("Are you sure you want to exit?");
            ExitMenuEnum selected = MenuHelper.GetResponse<ExitMenuEnum>();

            return selected == ExitMenuEnum.Yes;
        }

        internal void FindEndpoint()
        {
            Console.WriteLine("Please input the Serial Number of the enpoint:");
            var serialNumber = Console.ReadLine();
            var enpoint = CompanyService.FindEndpointBySerialNumber(serialNumber);

            if (enpoint == null)
            {
                Console.WriteLine("No endpoint with this Serial Number was found");
                return;
            }

            this.PrintEndpointInfo(enpoint);
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void PrintEndpointInfo(Endpoint enpoint)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(enpoint))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(enpoint);
                Console.WriteLine($"     {name} = {value};");
            }
            Console.WriteLine();
            return;
        }

        internal void ListEndpoints()
        {
            var enpointList = CompanyService.GetEndpoints();
            var count = 0;

            foreach (var endpoint in enpointList)
            {
                count++;
                Console.WriteLine($"Endpoint {count}:");
                PrintEndpointInfo(endpoint);
            }

            if (enpointList.Count == 0)
                Console.WriteLine("No endpoint were found.");

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            return;
        }

        internal void DeleteEndpoint()
        {
            Console.WriteLine("Please input the Serial Number of the enpoint to delete:");
            var serialNumber = Console.ReadLine();

            if (!this.CompanyService.HasEndpointWithSerialNumber(serialNumber))
            {
                this.EndProcess(DeleteEndpointResponseEnum.EndpointNotFound);
                return;
            }

            MenuHelper.WriteOptions<DeleteConfirmationEnum>("Are you sure you want to delete?");
            DeleteConfirmationEnum selected = MenuHelper.GetResponse<DeleteConfirmationEnum>();

            if (selected == DeleteConfirmationEnum.No)
                return;

            var response = this.CompanyService.DeleteEndpoint(serialNumber);
            this.EndProcess(response);
            return;
        }

        internal void EditEndpoint()
        {
            Console.WriteLine("Please input the Serial Number of the enpoint to edit:");
            var serialNumber = Console.ReadLine();

            var endpoint = this.CompanyService.FindEndpointBySerialNumber(serialNumber);
            if (endpoint == null)
            {
                this.EndProcess(EditEndpointResponseEnum.EndpointNotFound);
                return;
            }

            MenuHelper.WriteOptions<SwitchStateEnum>($"The Endpoint you selected is curently {endpoint.SwitchState.ToName()}. Select an option to change:");
            SwitchStateEnum newState = MenuHelper.GetResponse<SwitchStateEnum>();

            var response = this.CompanyService.EditEndpoint(serialNumber, newState);
            this.EndProcess(response);
            return;
        }

        internal void InsertEndpoint()
        {
            var newEndpoint = this.EndpointService.CreateEndpoint();
            var response = this.CompanyService.InsertEndpoint(newEndpoint);
            this.EndProcess(response);
            return;
        }

        private void EndProcess<T>(T response) where T : Enum
        {
            MenuHelper.WriteResponse(response);
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            return;
        }

    }
}
