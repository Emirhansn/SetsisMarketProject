using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SetsisMarketplace.Models
{
    public class DiscountDetail
    {
        public double lineItemPrice { get; set; }
        public double lineItemDiscount { get; set; }
    }
}