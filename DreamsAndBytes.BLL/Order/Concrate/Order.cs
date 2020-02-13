using DreamsAndBytes.BLL.Order.Abstract;
using DreamsAndBytes.Constants;
using DreamsAndBytes.DAL;
using DreamsAndBytes.Entity.Entities.Basket;
using DreamsAndBytes.Entity.Entities.Order;
using DreamsAndBytes.Entity.Entities.Product;
using DreamsAndBytes.Enums;
using DreamsAndBytes.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamsAndBytes.DAL.Concrate;
using DreamsAndBytes.DAL.Abstract;

namespace DreamsAndBytes.BLL.Order.Concrate
{
    public class Order : IOrder
    {
        private IOrderService _orderService;
        private IOrderDetailService _orderDetailService;
        private IBasketService _basketService;
        private IProductService _productService;

        public Order(IOrderService orderService, IOrderDetailService orderDetailService, IBasketService basketService, IProductService productService)
        {
            this._orderService = orderService;
            this._basketService = basketService;
            this._productService = productService;
            this._orderDetailService = orderDetailService;
        }

        public OrderEntity CreateOrder(int userId, PaymentTypeEnum paymentType)
        {
            ProductEntity product = null;
            List<BasketEntity> basketEntities = this._basketService.Get(x => x.UserID == userId && !x.IsDeleted).ToList();
            if(basketEntities != null && basketEntities.Count > 0)
            {
                DateTime now = DateTime.Now;
                OrderEntity orderEntity = new OrderEntity()
                {
                    AddDate = now,
                    IsDeleted = false,
                    OrderStatus = Enums.OrderStatusEnum.Waiting,
                    PaymentType = paymentType,
                    TotalAmount = 0,
                    UserID = userId
                };

                this._orderService.Add(orderEntity);
                this._orderService.SaveChanges();

                orderEntity = this._orderService.Get(x => x.UserID == userId && x.AddDate == now).FirstOrDefault();

                List<OrderDetailEntity> orderDetailEntities = new List<OrderDetailEntity>();

                Parallel.ForEach(basketEntities, (basket) =>
                {
                    product = this._productService.Get(x => x.ID == basket.ProductID && !x.IsDeleted).FirstOrDefault();
                    if(product != null)
                    {
                        orderEntity.TotalAmount += (basket.Count * product.Price);

                        this._orderDetailService.Add(new OrderDetailEntity
                        {
                            AddDate = DateTime.Now,
                            Count = basket.Count,
                            ProductID = basket.ProductID,
                            IsDeleted = false,
                            TotalAmount = (basket.Count * product.Price),
                            OrderID = orderEntity.ID
                        });
                    }

                    this._basketService.Delete(basket);
                });


                this._orderService.SaveChanges();
                return orderEntity;

            }
            return null;
        }

        public bool ValidateOrder(int orderId)
        {
            // Ürün silindi mi falan vs.
            return true;
        }
    }
}
