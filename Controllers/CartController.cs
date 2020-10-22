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
            
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            if (ViewBag.total == null) { return RedirectToAction("Products", "Index"); }


            return View();
        }

        [Route("orderCart")]
        public async Task<IActionResult> OrderAsync()
        {
            var user = await _userManager.GetUserAsync(User);


            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");


            //foreach (var item in cart)
            //{   _context.OrderHasProduct.Add()
            //
            //}
            //newShoppingcart.products.Add(product);
            //newShoppingcart.userID = userId;
            //_context.Shoppingcarts.Add(newShoppingcart);
            //_context.SaveChanges();

            //cart[index].Quantity++;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
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
