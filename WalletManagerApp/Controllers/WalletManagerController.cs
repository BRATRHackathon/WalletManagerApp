using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WalletManagerApp.Models;

namespace WalletManagerApp.Controllers
{
    public class WalletManagerController : ApiController
    {
        //http://localhost:46664/api/WalletManager/GetWalletByEmail?email=danielctrl@gmail.com
        public IHttpActionResult GetWalletByEmail(string email)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            var wallet = (new ApplicationDbContext()).Users.Where(x => x.Email == email).Select(x => x.WalletAddress).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(wallet))
                return Json("Nada encontrado");

            return Json(wallet);
        }

        //http://localhost:46664/api/WalletManager/GetEmailByWallet?wallet=0x11
        public IHttpActionResult GetEmailByWallet(string wallet)
        {
            var email = (new ApplicationDbContext()).Users.Where(x => x.WalletAddress == wallet).Select(x => x.Email).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(email))
                return Json("Nada encontrado");
            //return Content(HttpStatusCode.NoContent, "");

            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Json(email);
        }
    }
}