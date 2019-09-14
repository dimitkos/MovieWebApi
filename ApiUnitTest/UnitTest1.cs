using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using api.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetMovies()
        {
            var service = new DbImplementation();

            var response = service.GetMoviesFromDb();

            Xunit.Assert.NotNull(response.Movies);
            Xunit.Assert.True(response.Movies.ToList().Exists(x=>x.Title.Equals("A1") && x.Name.Equals("The Truth")));
        }

        
    }
}
