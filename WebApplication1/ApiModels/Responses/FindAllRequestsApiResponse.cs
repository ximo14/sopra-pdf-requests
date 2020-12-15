using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ApiModels.Responses {

    public class FindAllRequestsApiResponse {

        public IEnumerable<object> Requests { get; set; }

    }
}
