using System.Collections.Generic;
using WebApplication1.QueryModels;

namespace WebApplication1.Repositories {

    public interface IRequestRepository {

        IEnumerable<RequestQueryModel> GetAllRequestsQuery(string requestStatus = null);

    }
}