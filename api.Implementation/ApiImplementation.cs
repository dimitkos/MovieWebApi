using api.Interfaces;
using api.Types.Requests;
using api.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Implementation
{
    public class ApiImplementation
    {
        private readonly IDbService dbService;

        public ApiImplementation(IDbService dbService)
        {
            this.dbService = dbService;
        }

        public GetMoviesResponse GetMovies()
        {
            return dbService.GetMoviesFromDb();
        }

        public bool AddMovie(AddMovieRequest request)
        {
            if(CheckIfAddMovieRequestIsValid(request))
            {
                return dbService.AddMovieinDb(request);
            }
            return false;    
        }


        private bool CheckIfAddMovieRequestIsValid(AddMovieRequest request)
        {
            if(string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Description))
            {
                throw new Exception("Invalid Request");
            }
            return true;
        }
    }
}
