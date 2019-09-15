using api.Types.Requests;
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
            //PostMovie();
            //GetMoviesAndPrint();
            SetProject st = new SetProject();
            st.StartUpProject();
            //StartUpProject();
            //Console.ReadLine();
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

        public static void PostMovie()
        {
            Console.WriteLine("Please Enter the Title");
            string title = Console.ReadLine();
            Console.WriteLine("Please Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Please Enter the Description");
            string description = Console.ReadLine();

            AddMovieRequest request = new AddMovieRequest()
            {
                Title = title,
                Name = name,
                Description = description
            };

            var client = new RestClient("http://localhost:59881");
            var postRequest = new RestRequest("api/movie/addMovie", Method.POST);
            postRequest.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            postRequest.RequestFormat = DataFormat.Json;
        }

        public static void StartUpProject()
        {
            while(true)
            {
                Console.WriteLine("Please Choose Action");
                Console.WriteLine("[1] Get Movies");
                Console.WriteLine("[2] Add Movie");
                Console.WriteLine("[3] Update Movie");
                Console.WriteLine("[4] Delete Movie");

                string input = Console.ReadLine();

                if(input=="1")
                {
                    //call the get
                }
                else if(input == "2")
                {
                    //Console.WriteLine("Please Enter the Title");
                    //string title = Console.ReadLine();
                    //Console.WriteLine("Please Enter the Name");
                    //string name = Console.ReadLine();
                    //Console.WriteLine("Please Enter the Description");
                    //string description = Console.ReadLine();

                    //AddMovieRequest request = new AddMovieRequest()
                    //{
                    //    Title = title,
                    //    Name = name,
                    //    Description = description
                    //};

                    //var client = new RestClient("http://localhost:59881");
                    //var postRequest = new RestRequest("api/movie/getMovies", Method.POST);
                    //postRequest.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
                    //postRequest.RequestFormat = DataFormat.Json;
                }
                else if(input == "3")
                {
                    //update
                }
                else if(input == "4")
                {
                    //delete
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }

                Console.WriteLine("Would you like more actions?? [Y] or [N]");
                var answer = Console.ReadLine();
                if(answer == "Y" || answer == "y")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
