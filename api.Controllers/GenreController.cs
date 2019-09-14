using api.Interfaces;
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
    public class GenreController : ApiController
    {
        private readonly IApiService apiService;

        public GenreController(IApiService apiService)
        {
            this.apiService = apiService;
        }

        [HttpGet]
        [ActionName("getAllGenres")]
        public HttpResponseMessage GetGenres()
        {
            var response = apiService.GetGenres();

            if (response.Genres != null)
            {
                return Request.CreateResponse<GetGenresResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, " Genres Not Found");
            }
        }
    }
}
