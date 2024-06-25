using QuantumStock.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumStock.Shared.Response
{
    public class PaymentItem
    {

        public List<PaymentItemList> paymentListsItems { get; set; }
    }
}