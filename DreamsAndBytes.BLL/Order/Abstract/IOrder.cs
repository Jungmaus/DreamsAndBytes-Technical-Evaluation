using DreamsAndBytes.Entity.Entities.Order;
using DreamsAndBytes.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.BLL.Order.Abstract
{
    public interface IOrder
    {
        bool ValidateOrder(int orderId);
        OrderEntity CreateOrder(int userId, PaymentTypeEnum paymentType);
    }
}
