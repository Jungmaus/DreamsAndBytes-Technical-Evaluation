using DreamsAndBytes.BLL.Payment.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.BLL.Payment
{
    public class PaymentManager : IPayment
    {
        private IPayment _payment;

        public PaymentManager(IPayment payment)
        {
            this._payment = payment;
        }

        public bool Pay(int orderId) => this._payment.Pay(orderId);

    }
}
