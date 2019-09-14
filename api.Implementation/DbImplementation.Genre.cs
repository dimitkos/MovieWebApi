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
        public GetGenresResponse GetGenresFromDb()
        {
            string sql = @"Select * From genre with (nolock)";
            using (var con = GetSqlConnection())
            {
                var response = con.Query<Genre>(sql);

                return new GetGenresResponse()
                {
                    Genres = response
                };
            }
        }
    }
}
