using DreamsAndBytes.BLL.Payment.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.BLL.Payment.Concrate
{
    public class KissPayment : IPayment
    {
        public bool Pay(int orderId)
        {
            Console.WriteLine(" :* ");
            return true;
        }
    }
}
