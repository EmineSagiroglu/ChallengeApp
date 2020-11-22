using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challengeApp.WebUI.Models
{
    public class ProductCreateModels
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public float ProductPrice { get; set; }
        public string ProductDefinition { get; set; }
    }
}
