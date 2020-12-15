using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.QueryModels;
using WebApplication1.Repositories;

namespace WebApplication1.Services {

    public class RequestService : 
        IRequestService {

        private ILogger Logger { get; set; }

        private IRequestRepository RequestRepository { get; set; }

        public RequestService(
            ILogger<RequestService> logger,
            IRequestRepository requestRepository) {

            this.Logger = logger;

            this.RequestRepository = requestRepository;

        }

        public RequestListPdfModel FindAllRequestsByStatus(
            string requestStatus) {

            this.Logger.LogInformation("RequestService :: FindAllRequests start");

            IEnumerable<RequestQueryModel> requestsQueryModel = this.RequestRepository.GetAllRequestsQuery(requestStatus);

            RequestListPdfModel requests = new RequestListPdfModel();

            IList<RequestPdfModel> requestList = new List<RequestPdfModel>();

            foreach (RequestQueryModel requestQueryModel in requestsQueryModel) {

                RequestPdfModel model = new RequestPdfModel() {
                    Dni = "*****" + requestQueryModel.soli_DNI.Substring(requestQueryModel.soli_DNI.Length - 3),
                    Name = requestQueryModel.soli_Nombre,
                    Surname = string.Join(" ", requestQueryModel.soli_Apellido1, requestQueryModel.soli_Apellido2),
                    Status = requestQueryModel.soli_EstadoSolicitud,
                    ReasonReject = requestQueryModel.soli_MotivoDenegacion
                };

                requestList.Add(model);

            }

            requests.Requests = requestList;

            this.Logger.LogInformation("RequestService :: FindAllRequests start");

            return requests;

        }

    }
}
