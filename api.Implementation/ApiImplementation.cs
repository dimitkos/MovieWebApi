using api.Interfaces;
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
    }
}
