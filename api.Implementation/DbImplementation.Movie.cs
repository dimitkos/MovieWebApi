using api.Types.DbTypes;
using api.Types.Responses;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Implementation
{
    public partial class DbImplementation
    {
        public GetMoviesResponse GetMovies()
        {
            string sql = @"Select * From movie with no lock";
            using (var con = GetSqlConnection())
            {
                var response = con.Query<Movie>(sql);

                return new GetMoviesResponse()
                {
                    Movies = response
                };
            }
        }
    }
}
