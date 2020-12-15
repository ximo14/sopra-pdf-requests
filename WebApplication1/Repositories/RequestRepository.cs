using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Config;
using WebApplication1.QueryModels;

namespace WebApplication1.Repositories {

    public class RequestRepository : 
        IRequestRepository {

        private IConfiguration Configuration { get; set; }

        public RequestRepository(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        public IEnumerable<RequestQueryModel> GetAllRequestsQuery(string requestStatus) {

            string sql = "SELECT * FROM GPS_SOLICITUDS WHERE (@RequestStatus IS NULL OR soli_EstadoSolicitud = @RequestStatus)";

            using (var connection = new SqlConnection(this.Configuration.GetConnectionString("SqlServer"))){

                IEnumerable <RequestQueryModel> requestsData = connection.Query<RequestQueryModel>(sql, new { RequestStatus = requestStatus }).ToList();

                return requestsData;
            }

        }
    }
}
