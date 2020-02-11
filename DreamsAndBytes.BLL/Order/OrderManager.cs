using DreamsAndBytes.BLL.Order.Abstract;
using DreamsAndBytes.Entity.Entities.Order;
using DreamsAndBytes.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.BLL.Order
{
    public class OrderManager : IOrder
    {
        private IOrder _order;

        public OrderManager(IOrder order)
        {
            this._order = order;
        }
       
        public OrderEntity CreateOrder(int userId, PaymentTypeEnum paymentType) => this._order.CreateOrder(userId, paymentType);

        public bool ValidateOrder(int orderId) => this._order.ValidateOrder(orderId);
    }
}
