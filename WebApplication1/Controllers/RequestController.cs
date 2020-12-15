using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController :
        Controller {

        private IRequestService RequestService { get; set; }

        private ILogger Logger { get; set; }

        public RequestController(
            ILogger<RequestController> logger,
            IRequestService requestService) {

            this.Logger = logger;

            this.RequestService = requestService;

        }

        // GET: api/Requests
        [HttpGet]
        public Byte[] GetRequestsListPdf(string requestStatus = null) {

            this.Logger.LogInformation("RequestController :: GetRequestsListPdf start");

            RequestListPdfModel response = this.RequestService.FindAllRequestsByStatus(requestStatus);

            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = PdfGenerator.GeneratePdf(View("Pdf", response).ToString(), PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }

            this.Logger.LogInformation("RequestController :: GetRequestsListPdf end");

            return res;

        }
    }
}
