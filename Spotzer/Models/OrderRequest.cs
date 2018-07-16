using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spotzer.Models
{
    public class OrderRequest
    {
        //we can set required attribute to other properties if needed
        [Required]
        public string Partner { get; set; }
        public string OrderID { get; set; }
        public string TypeOfOrder { get; set; }
        public string SubmittedBy { get; set; }
        public string CompanyID { get; set; }
        public string ContractFirstName { get; set; }
        public string CompanyName { get; set; }
        public string ExposureId { get; set; }
        public List<ProductBase> LineItems { get; set; }
    }
}