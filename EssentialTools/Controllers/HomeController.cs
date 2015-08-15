using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;

        private Product[] products = {
                                         new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                                         new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                                         new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                                         new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}

                                     };

        public HomeController(IValueCalculator calcParam, IValueCalculator calc2)
        {
            calc = calcParam;
        }
        // GET: Home
        public ActionResult Index()
        {
            //create instance of ninject kernel
            //its the object responsible for resolving dependencies and creating new object
            //IKernel ninjectKernel = new StandardKernel();

            //lets MVC know that IValueCalcultor is implementing the LinqValueCalculator class
            //Dependencies on the IValueCalculator interface shuld be resolved by creating an instace of the LinqValueCalculator Class
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            //ninject creates the calc object
            //Get parameter tells ninject what interface I;m interested in
            //this returns an instance of the class object inthe To method above : LinqValueCalculator
            //IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}