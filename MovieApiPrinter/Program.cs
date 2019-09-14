using api.Types.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApiPrinter
{
    class Program
    {
        static void Main(string[] args)
        {

            GetMoviesAndPrint();

            Console.ReadLine();
        }

        public static void GetMoviesAndPrint()
        {
            var client = new RestClient("http://localhost:59881");
            var request = new RestRequest("api/movie/getMovies", Method.GET);
            var queryResult = client.Get<GetMoviesResponse>(request).Data;

            foreach(var movie in queryResult.Movies)
            {
                Console.WriteLine("Title: " + movie.Title);
                Console.WriteLine("Name: " + movie.Name);
                Console.WriteLine("Description " + movie.Description);
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }
    }
}
