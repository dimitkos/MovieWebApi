﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace api.Types.Requests
{
    [DataContract]
    public class DeleteGenreRequest
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}
