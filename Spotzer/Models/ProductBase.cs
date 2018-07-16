using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spotzer.Models
{
    public class ProductBase
    {
        [Required]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ProductType { get; set; }
        public string Notes { get; set; }
        public string Category { get; set; }
        public WebsiteProduct WebsiteDetails { get; set; }
        public PaidSearchProduct AdWordCampaign { get; set; }
    }
}