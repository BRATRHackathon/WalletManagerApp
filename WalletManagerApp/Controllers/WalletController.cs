using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WalletManagerApp.Models;

namespace WalletManagerApp.Controllers
{
    public class WalletController : Controller
    {
        [HttpPost]
        public ActionResult Create(WalletViewModel viewModel)
        {
            // SAVE viewModel data
            return View();
        }
    }
}