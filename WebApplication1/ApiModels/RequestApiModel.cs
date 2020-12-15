using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ApiModels {

    public class RequestApiModel {
            
        //DNI codigficado
        public string EncodedDNI { get; set; }
            
        //-Nombre Personal
        public string FullName { get; set; }
        
        //-Estado
        public string RequestStatus { get; set; }
        
        //-Motivo Rechazo
        public string ReasonReject { get; set; }

    }
}
