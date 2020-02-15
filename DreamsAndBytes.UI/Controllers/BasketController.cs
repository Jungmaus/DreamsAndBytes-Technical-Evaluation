using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DreamsAndBytes.BLL.Order;
using DreamsAndBytes.BLL.Order.Abstract;
using DreamsAndBytes.BLL.Payment;
using DreamsAndBytes.BLL.Payment.Abstract;
using DreamsAndBytes.BLL.Payment.Concrate;
using DreamsAndBytes.DAL.Abstract;
using DreamsAndBytes.Entity.Entities.Basket;
using DreamsAndBytes.Entity.Entities.Order;
using DreamsAndBytes.Enums;
using DreamsAndBytes.UI.Models.Basket;
using DreamsAndBytes.UI.Models.Payment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using static DreamsAndBytes.UI.Startup;

namespace DreamsAndBytes.UI.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IOrder _order;
        //private readonly IPayment _payment;
        private readonly PaymentServiceResolver _paymentServiceResolver;

        public BasketController(IBasketService basketService, IProductService productService, IOrder order, IMapper mapper, IPayment payment, PaymentServiceResolver paymentServiceResolver)
        {
            this._basketService = basketService;
            this._mapper = mapper;
            this._productService = productService;
            this._order = order;
            //this._payment = payment;
            this._paymentServiceResolver = paymentServiceResolver;
        }

        public IActionResult Index()
        {
            string userId = GetClaimValue(ClaimTypes.NameIdentifier);
            if (userId != null && userId != string.Empty)
            {
                var baskets = _basketService.Get(x => x.UserID == int.Parse(userId) && !x.IsDeleted).ToList();
                
                List<BasketVM> model = _mapper.Map<List<BasketVM>>(baskets);
                Parallel.ForEach(model, (item) =>
                {
                    item.Product = _productService.Get(x => x.ID == item.ProductID && !x.IsDeleted).FirstOrDefault();
                });

                return View(model);
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult RemoveProductFromBasket(int basketId)
        {
            string userId = GetClaimValue(ClaimTypes.NameIdentifier);
            if (userId != null && userId != string.Empty)
            {
                var basket = _basketService.Get(x => x.UserID == int.Parse(userId) && x.ID == basketId && !x.IsDeleted).FirstOrDefault();

                if (basket != null)
                {
                    _basketService.Delete(basket);
                    _basketService.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }

        public IActionResult PaymentDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PaymentDetails(PaymentVM model)
        {
            if(ModelState.IsValid)
            {
                // Manager içerisinde ekstra işlemler yapılsaydı böyle kullanabilirdim ama basit tutuyorum;
                //OrderManager orderManager = new OrderManager(_order);
                //orderManager.CreateOrder();

                OrderEntity orderEntity = _order.CreateOrder(
                     userId: int.Parse(GetClaimValue(ClaimTypes.NameIdentifier)),
                     paymentType: model.PaymentType
                     );

                if (orderEntity is null)
                    throw new Exception("Sipariş tamamlanamadı.");
                else if (!_order.ValidateOrder(orderEntity.ID))
                    throw new Exception("Siparişteki ürünler geçersiz.");

                // Ödeme tamamlandı, sanal pos vs.
                IPayment payment = _paymentServiceResolver(model.PaymentType);
                payment.Pay(orderEntity.ID);

                return RedirectToAction("Complete", "Basket", new { orderId = orderEntity.ID });
            }
            return View();
        }

        public IActionResult Complete(int orderId)
        {
            // Her şey hazır. Sipariş numarası falan gösterilen sayfa burası.

            ViewBag.orderId = orderId;

            return View();
        }        

        [HttpPost]
        public void AddProductToBasket(int id)
        {
            string userId = GetClaimValue(ClaimTypes.NameIdentifier);
            if (userId != null && userId != string.Empty)
            {
                var basket = _basketService.Get(x => x.UserID == int.Parse(userId) && x.ProductID == id && !x.IsDeleted).FirstOrDefault();

                if (basket is null)
                {
                    BasketEntity basketEntity = new BasketEntity(int.Parse(userId), id, 1, DateTime.Now, false);
                    _basketService.Add(basketEntity);
                }
                else
                {
                    var product = _productService.Get(x => x.ID == id && !x.IsDeleted).FirstOrDefault();
                    if (product != null && product.StockCount >= 1)
                    {
                        basket.Count += 1;
                        _basketService.Update(basket);
                    }
                }
                _basketService.SaveChanges();
            }
        }
    }
}