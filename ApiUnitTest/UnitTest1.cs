using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using api.Implementation;
using api.Types.DbTypes;
using api.Types.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly DbImplementation service;

        public UnitTest1()
        {
            service = new DbImplementation();
        }

        [TestMethod]
        public void GetMovies()
        {
            var response = service.GetMoviesFromDb();

            Xunit.Assert.NotNull(response.Movies);
            Xunit.Assert.True(response.Movies.ToList().Exists(x=>x.Title.Equals("A1") && x.Name.Equals("The Truth")));
        }

        [TestMethod]
        public void AddMovie()
        {
            AddMovieRequest request = new AddMovieRequest()
            {
                Title = "A10",
                Name = "TEST NAME",
                Description = "TEST DESCRIPTION"
            };

            var response = service.AddMovieinDb(request);

            Xunit.Assert.True(response);

        }

        [TestMethod]
        public void UpdateMovie()
        {
            Movie request = new Movie()
            {
                Title = "A10",
                Name = "Update TEST NAME",
                Description = "Update TEST DESCRIPTION"
            };

            var response = service.UpdateMovieInDb(request);

            Xunit.Assert.True(response);
        }

        [TestMethod]
        public void DeleteMovie()
        {
            DeleteMovieRequest request = new DeleteMovieRequest()
            {
                Title = "A10"
            };

            var response = service.DeleteMovieFromDB(request);

            Xunit.Assert.True(response);
        }
    }
}
