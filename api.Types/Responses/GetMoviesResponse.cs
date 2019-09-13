using api.Types.DbTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace api.Types.Responses
{
    [DataContract]
    public class GetMoviesResponse
    {
        [DataMember(Name = "movies")]
        public IEnumerable<Movie> Movies { get; set; }
    }
}
