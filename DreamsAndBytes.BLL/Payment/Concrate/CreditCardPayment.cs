using DreamsAndBytes.BLL.Payment.Abstract;
using DreamsAndBytes.Builder;
using DreamsAndBytes.Constants;
using DreamsAndBytes.DAL;
using DreamsAndBytes.DAL.Concrate;
using DreamsAndBytes.Entity.Entities.Basket;
using DreamsAndBytes.Entity.Entities.Order;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DreamsAndBytes.BLL.Payment.Concrate
{
    public class CreditCardPayment : IPayment
    {
        private OrderService _orderService;

        public CreditCardPayment(OrderService orderService)
        {
            this._orderService = orderService;
        }

        public bool Pay(int orderId)
        {
            OrderEntity order = this._orderService.Get(x => x.ID == orderId && !x.IsDeleted && x.OrderStatus == Enums.OrderStatusEnum.Waiting).FirstOrDefault();
            if (order is null)
                return false;

            try
            {
                Trace.TraceInformation(MessageBuilder.GenerateMessage(message: PaymentConstants.Messages.Information, order.ID.ToString()));

                // SANAL POS İŞLEMLERİ VS. VS.

                order.OrderStatus = Enums.OrderStatusEnum.Success;
                this._orderService.Update(order);
                this._orderService.SaveChanges();

                Trace.TraceInformation(MessageBuilder.GenerateMessage(message: PaymentConstants.Messages.Success, order.ID.ToString()));

                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError(MessageBuilder.GenerateMessage(message: PaymentConstants.Messages.Failure, order.ID.ToString() + " |||||| " + ex.ToString()));

                try
                {
                    order.OrderStatus = Enums.OrderStatusEnum.Failure;
                    this._orderService.Update(order);
                    this._orderService.SaveChanges();
                }
                catch { }

                return false;
            }

        }
    }
}
