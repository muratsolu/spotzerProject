using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Spotzer.Models
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> ErrorList{ get; set; }
        public HttpResponseMessage httpResponseMessage { get; set; }
    }
}