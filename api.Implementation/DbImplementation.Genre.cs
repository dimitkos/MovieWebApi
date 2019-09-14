using api.Types.DbTypes;
using api.Types.Requests;
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

        public bool AddGenreInDb(AddGenreRequest request)
        {
            string sql = @"INSERT INTO Genre (Title,Name,Description,MovieYitle) VALUES (@Title,@Name,@Description,@MovieTitle) ";
            int result;
            using (var con = GetSqlConnection())
            {
                var parameters = new { request.Title, request.Name, request.Description };
                result = con.QuerySingleOrDefault<int>(sql, parameters);
            }
            return result == 1;
        }

        public bool UpdateGenreInDb(Genre request)
        {
            string sql = @"UPDATE Genre SET Name = @Name, Description = @Description , MovieTitle = @MovieTitle WHERE Title = @Title ";
            int result;
            using (var con = GetSqlConnection())
            {
                var parameters = new { request.Title, request.Name, request.Description,request.MovieTitle };
                result = con.QuerySingleOrDefault<int>(sql, parameters);
            }
            return result == 1;
        }

        public bool DeleteGenreFromDB(DeleteGenreRequest request)
        {
            string sql = @"DELETE FROM  Genre WHERE Title=@Title";
            int result;
            using (var con = GetSqlConnection())
            {
                var parameters = new { request.Title };
                result = con.QuerySingleOrDefault<int>(sql, parameters);
            }
            return result == 1;
        }
    }
}
