using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarLand.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuitarLand.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;

        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }

        public ViewResult List() => View(repository.Orders);



        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult DeleteOrder(int orderID)
        {
            Order deletedOrder = repository.DeleteOrder(orderID);
            if (deletedOrder != null)
            {
                TempData["message"] = $"{deletedOrder.Name} was deleted";
            }
            return RedirectToAction("List");
        }

    }
}
