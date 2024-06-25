using QuantumStock.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumStock.Shared.Response
{
    public class SalesListResponse
    {
        public IEnumerable<GroupedData> GroupedData { get; set; }
        public IEnumerable<PaymentItem> PaymentItem { get; set; }
        public decimal PurchaseDataSum { get; set; }
    }
}