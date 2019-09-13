using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.Business
{
    public class CashBusiness : ICashBusiness
    {
        public string PaymentType()
        {
            return "Cash Payment";
        }
    }
}
