using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Helpers;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using BookStore.Controllers;
using BookStore.Data;
using Microsoft.AspNetCore.Identity;
using SQLitePCL;
using Microsoft.AspNetCore.Http;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {


        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public CartController(UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        


        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            ViewBag.cart = cart;

            if (ViewBag.total == null) { return RedirectToAction("Index", "Products"); }

            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            


            return View();
        }

        [Route("ProcessOrder")]
        public async Task<IActionResult> ProcessOrder(IFormCollection frc)
        {
            var user = await _userManager.GetUserAsync(User);


            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            Orders order = new Orders()
            {   
                
               // Amount = ViewBag.total,
                ApplicationUserId = user.Id,
                OrderDate = DateTime.Now,
                Firstname = frc["cusFirstName"],
                Lastname = frc["cusLastName"],
                DeliveryAddress = frc["cusAddress"],
                DeliveryCity = frc["cusCity"],
                DeliveryZip = frc["cusZip"],
                PhoneNumber = frc["cusPhone"],
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in cart)
            {
                OrderHasProduct orderHasProduct = new OrderHasProduct()
                {

                    OrderId = order.OrderId,
                    ProductId = item.Product.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                };
                _context.OrderHasProduct.Add(orderHasProduct);
                _context.SaveChanges();
            }

            cart.Clear();
            
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return View("OrderSucess");
        }






        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            Product product = new Product();
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                var buyproduct = _context.Product.Single(p => p.ProductId.Equals(id));
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = buyproduct, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    var buyproduct = _context.Product.Single(p => p.ProductId.Equals(id));
                    cart.Add(new Item { Product = buyproduct, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        [Route("buy2/{id}/{count}")]
        public IActionResult BuyMultiple(int id, int count)
        {
            Product product = new Product();
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                var buyproduct = _context.Product.Single(p => p.ProductId.Equals(id));
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = buyproduct, Quantity = count });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    var buyproduct = _context.Product.Single(p => p.ProductId.Equals(id));
                    cart.Add(new Item { Product = buyproduct, Quantity = count });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        [Route("minus/{id}")]
        public IActionResult Minus(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart[index].Quantity--;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        [Route("plus/{id}")]
        public IActionResult Plus(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart[index].Quantity++;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        [Route("CheckOut")]
        public IActionResult CheckOut()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            ViewBag.cart = cart;

            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View("CheckOut");
        }

        public ActionResult CartSummary()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            var itemCount = 0;

            foreach (var item in cart)
            {
                itemCount++;
            }

            ViewData["CartCount"] = itemCount; // count Qty in your cart
            return PartialView("CartSummary");
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
