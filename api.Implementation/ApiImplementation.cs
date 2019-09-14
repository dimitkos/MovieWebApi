using api.Interfaces;
using api.Types.DbTypes;
using api.Types.Requests;
using api.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Implementation
{
    public class ApiImplementation : IApiService
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


        public bool UpdateMovie(Movie request)
        {
            if (CheckIfUpdateMovieRequestIsValid(request))
            {
                return dbService.UpdateMovieInDb(request);
            }
            return false;
            
        }

        public bool DeleteMovie(DeleteMovieRequest request)
        {
            if (CheckIfDeleteMovieRequestIsValid(request))
            {
                return dbService.DeleteMovieFromDB(request);
            }
            return false;
        }

        public GetGenresResponse GetGenres()
        {
            return dbService.GetGenresFromDb();
        }

        #region private methods

        private bool CheckIfDeleteMovieRequestIsValid(DeleteMovieRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                throw new Exception("Invalid Request");
            }
            return true;
        }

        private bool CheckIfUpdateMovieRequestIsValid(Movie request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Description))
            {
                throw new Exception("Invalid Request");
            }
            return true;
        }

        private bool CheckIfAddMovieRequestIsValid(AddMovieRequest request)
        {
            if(string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Description))
            {
                throw new Exception("Invalid Request");
            }
            return true;
        }

        #endregion
    }
}
