using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Domain.Common
{
 public  class RequestResult
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public object Value { get; set; }

        public bool HasValidationErrors { get; set; }

        public List<ObjectErrors> ValidationErrors { get; set; }

        public RequestResult()
        {
            ValidationErrors = new List<ObjectErrors>();
        }

        public RequestResult(bool status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public RequestResult(bool status, object data)
        {
            if (!status)
            {
                this.Message = "Ha ocurrido un error inesperado";
            }
            else
            {
                this.Message = "Operación Exitosa";
            }


            this.Value = data;
        }

        public RequestResult(bool status, string message, object Data)
        {
            this.Status = status;
            this.Message = message;
            this.Value = Data;
        }
    }
}
