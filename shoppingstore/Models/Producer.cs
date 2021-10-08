using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shoppingstore.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }
        public string Name { get; set; }

    }
}