using api.Types.Requests;
using api.Types.Responses;
using RestSharp;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApiPrinter
{
    
    class Program
    {
        private static readonly Container container;
        static Program()
        {
            container = new Container();
            container.Register<ISetUpService, SetProject>();
            container.Verify();
        }
        static void Main(string[] args)
        {

            var service = container.GetInstance<ISetUpService>();
            service.StartUpProject();
        }
        
    }
}
