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
    public class MovieEndPoints
    {
        public void GetMoviesAndPrint()
        {
            var response = ExecuteGetMovies();

            PrintMovies(response);
        }

        public void AddMovie()
        {
            var request = AddMovieInputRequest();

            ExecutePostRequest(request);
        }

        #region private methods

        private AddMovieRequest AddMovieInputRequest()
        {
            Console.WriteLine("Please Enter the Title");
            string title = Console.ReadLine();
            Console.WriteLine("Please Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Please Enter the Description");
            string description = Console.ReadLine();

            return new AddMovieRequest()
            {
                Title = title.Trim(),
                Name = name.Trim(),
                Description = description.Trim()
            };
        }

        private void ExecutePostRequest(AddMovieRequest request)
        {
            var client = new RestClient("http://localhost:59881");
            var postRequest = new RestRequest("api/movie/addMovie", Method.POST);
            postRequest.AddJsonBody(request);
            postRequest.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            postRequest.RequestFormat = DataFormat.Json;
            client.Execute(postRequest);
        }

        private GetMoviesResponse ExecuteGetMovies()
        {
            var client = new RestClient("http://localhost:59881");
            var request = new RestRequest("api/movie/getMovies", Method.GET);
            var queryResult = client.Get<GetMoviesResponse>(request).Data;

            return queryResult;
        }

        private void PrintMovies(GetMoviesResponse getMoviesResponse)
        {
            foreach (var movie in getMoviesResponse.Movies)
            {
                Console.WriteLine("Title: " + movie.Title);
                Console.WriteLine("Name: " + movie.Name);
                Console.WriteLine("Description " + movie.Description);
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

        #endregion

    }
}
