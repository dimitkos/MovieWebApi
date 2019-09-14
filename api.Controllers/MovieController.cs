using api.Interfaces;
using api.Types.DbTypes;
using api.Types.Requests;
using api.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace api.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IApiService apiService;

        public MovieController(IApiService apiService)
        {
            this.apiService = apiService;
        }

        [HttpGet]
        [ActionName("getMovies")]
        public HttpResponseMessage GetMovies()
        {
            var response = apiService.GetMovies();

            if (response.Movies != null)
            {
                return Request.CreateResponse<GetMoviesResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, " Movies Not Found");
            }
        }

        [HttpPost]
        [ActionName("addMovie")]
        public HttpResponseMessage AddMovie([FromBody]AddMovieRequest request)
        {
            var response = apiService.AddMovie(request);

            if (response == true)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, " Movie Not Added");
            }
        }

        [HttpPut]
        [ActionName("updateMovie")]
        public HttpResponseMessage UpdateMovie([FromBody] Movie request)
        {
            var response = apiService.UpdateMovie(request);

            if (response == true)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, " Movie Not Updated");
            }
        }

        [HttpDelete]
        [ActionName("deleteMovie")]
        public HttpResponseMessage DeleteMovie([FromBody] DeleteMovieRequest request)
        {
            var response = apiService.DeleteMovie(request);

            if (response == true)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, " Movie Not Deleted");
            }
        }

    }
}
