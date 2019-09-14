using api.Types.DbTypes;
using api.Types.Requests;
using api.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IDbService
    {
        GetMoviesResponse GetMoviesFromDb();

        bool AddMovieinDb(AddMovieRequest request);

        bool UpdateMovieInDb(Movie request);

        bool DeleteMovieFromDB(DeleteMovieRequest request);

        GetGenresResponse GetGenresFromDb();

        bool AddGenreInDb(AddGenreRequest request);

        bool UpdateGenreInDb(Genre request);

        bool DeleteGenreFromDB(DeleteGenreRequest request);
    }
}
