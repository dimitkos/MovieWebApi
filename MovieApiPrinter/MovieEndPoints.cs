using api.Types.DbTypes;
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
            var res  = ExecutePostRequest(request);
            CheckReturnStatus(res);
        }

        public void UpdateMovie()
        {
            var request = UpdateInputRequest();
            var res = ExecuteUpdateRequest(request);
            CheckReturnStatus(res);
        }

        public void DeleteMovie()
        {
            var request = DeleteInputRequest();
            var res = ExecuteDeleteRequest(request);
            CheckReturnStatus(res);
        }

        #region private methods

        private DeleteMovieRequest DeleteInputRequest()
        {
            Console.WriteLine("Please Enter the Title");
            string title = Console.ReadLine();

            return new DeleteMovieRequest
            {
                Title = title.Trim()
            };
        }

        private Movie UpdateInputRequest()
        {
            Console.WriteLine("Please Enter the Title");
            string title = Console.ReadLine();
            Console.WriteLine("Please Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Please Enter the Description");
            string description = Console.ReadLine();

            return new Movie
            {
                Title = title.Trim(),
                Name = name.Trim(),
                Description = description.Trim()
            };
        }

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

        private IRestResponse ExecuteUpdateRequest(Movie request)
        {
            var client = new RestClient("http://localhost:59881");
            var updateRequest = new RestRequest("api/movie/updateMovie", Method.PUT);
            updateRequest.AddJsonBody(request);
            updateRequest.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            updateRequest.RequestFormat = DataFormat.Json;
            var status = client.Execute(updateRequest);
            return status;
        }

        private IRestResponse ExecutePostRequest(AddMovieRequest request)
        {
            var client = new RestClient("http://localhost:59881");
            var postRequest = new RestRequest("api/movie/addMovie", Method.POST);
            postRequest.AddJsonBody(request);
            postRequest.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            postRequest.RequestFormat = DataFormat.Json;
            var status = client.Execute(postRequest);
            return status;
        }

        private GetMoviesResponse ExecuteGetMovies()
        {
            var client = new RestClient("http://localhost:59881");
            var request = new RestRequest("api/movie/getMovies", Method.GET);
            var queryResult = client.Get<GetMoviesResponse>(request).Data;

            return queryResult;
        }

        private IRestResponse ExecuteDeleteRequest(DeleteMovieRequest request)
        {
            var client = new RestClient("http://localhost:59881");
            var deleteRequest = new RestRequest("api/movie/deleteMovie", Method.DELETE);
            deleteRequest.AddJsonBody(request);
            deleteRequest.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            deleteRequest.RequestFormat = DataFormat.Json;
            var status = client.Execute(deleteRequest);
            return status;
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

        private void CheckReturnStatus(IRestResponse res)
        {
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("The translaction is sucessfull");
            }
            else
            {
                Console.WriteLine("Something goes wrong ...: " + res.ErrorException);
            }
        }

        #endregion

    }
}
