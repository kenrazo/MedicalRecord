using MedicalRecord.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.Business.Factories
{
    public class PaymentTypeFactory : IPaymentTypeFactory
    {

        public IPaymentTypeBusiness GetPaymentType(int paymentType)
        {
            switch ((PaymentTypeEnum)Convert.ToInt16(paymentType))
            {
                case PaymentTypeEnum.Cash:
                    return new CashBusiness();
                case PaymentTypeEnum.CreditCard:
                    return new CreditCardBusiness();
                default:
                    return null;
            }
        }
    }
}