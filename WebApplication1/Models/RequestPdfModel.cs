using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models {

    public class RequestPdfModel {

        public string Dni { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Status { get; set; }

        public string ReasonReject { get; set; }

    }
}
