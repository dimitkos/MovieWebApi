﻿using api.Types.DbTypes;
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

        public bool AddMovie(AddMovieRequest request)
        {
            string sql = @"INSERT INTO Movie (Title,Name,Description) VALUES (@Title,@Name,@Description) ";
            int result;
            using (var con = GetSqlConnection())
            {
                var parameters = new { request.Title, request.Name, request.Description };
                result = con.QuerySingleOrDefault<int>(sql, parameters);
            }
            return result == 1;
        }

        public bool UpdateMovie(Movie request)
        {
            string sql = @"UPDATE Movie SET Name = @Name, Description = @Description WHERE Title = @Title ";
            int result;
            using (var con = GetSqlConnection())
            {
                var parameters = new { request.Title, request.Name, request.Description };
                result = con.QuerySingleOrDefault<int>(sql, parameters);
            }
            return result == 1;
        }

        public bool DeleteMovie(DeleteMovieRequest request)
        {
            string sql = @"DELETE FROM  Movie WHERE Title=@Title";
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