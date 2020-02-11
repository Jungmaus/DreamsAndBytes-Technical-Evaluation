using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.BLL.Payment.Abstract
{
    public interface IPayment
    {
        bool Pay(int orderId);
    }
}
