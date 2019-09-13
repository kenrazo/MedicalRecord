using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.Business
{
    public class CreditCardBusiness : ICreditCardBusiness
    {
        public string PaymentType()
        {
            return "Credit Card Payment";
        }
    }
}
