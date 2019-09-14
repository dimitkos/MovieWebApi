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
    public interface IApiService
    {
        GetMoviesResponse GetMovies();

        bool AddMovie(AddMovieRequest request);

        bool UpdateMovie(Movie request);

        bool DeleteMovie(DeleteMovieRequest request);

        GetGenresResponse GetGenres();

        bool AddGenre(AddGenreRequest request);

        bool UpdateGenre(Genre request);

        bool DeleteGenre(DeleteGenreRequest request);
    }
}
