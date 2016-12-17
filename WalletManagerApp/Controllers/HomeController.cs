using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WalletManagerApp.Models;

namespace WalletManagerApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message = "")
        {
            ViewBag.Title = "Wallet Manager";
            ViewBag.Message = WebUtility.HtmlEncode(message);
            if (Request.IsAuthenticated)
            {
                var id = User.Identity.GetUserId();
                var Wallets = (new ApplicationDbContext()).Users
                    .Where(x => x.Id == id)
                    .Select(x => new { x.WalletAddress, x.WalletSeed }).FirstOrDefault();

                ViewBag.WalletAddr = Wallets.WalletAddress;
                ViewBag.WalletSeed = String.Join(" ", Wallets.WalletSeed.Split().Take(3));
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}