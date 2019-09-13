using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.Business.Factories
{
    public interface IPaymentTypeFactory
    {
        IPaymentTypeBusiness GetPaymentType(int paymentType);
    }
}
