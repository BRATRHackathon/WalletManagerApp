using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WalletManagerApp.Models;

namespace WalletManagerApp.Controllers
{
    public class WalletManagerController : ApiController
    {
        //http://localhost:46664/api/WalletManager/GetWalletByEmail?email=danielctrl@gmail.com
        public IHttpActionResult GetWalletByEmail(string email)
        {            
            var wallet = (new ApplicationDbContext()).Users.Where(x => x.Email == email).Select(x => x.WalletAddress).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(wallet))
                return NotFound();

            return Ok(wallet);
        }

        //http://localhost:46664/api/WalletManager/GetEmailByWallet?wallet=0x11
        public IHttpActionResult GetEmailByWallet(string wallet)
        {
            var email = (new ApplicationDbContext())
                .Users
                .Where(x =>
                    x.WalletAddress == wallet.Replace("0x", "") ||
                    x.WalletAddress == wallet ||
                    x.WalletAddress == ("0x" + wallet)
                )
                .Select(x => x.Email)
                .FirstOrDefault();
            
            if (string.IsNullOrWhiteSpace(email))
                return NotFound();            
                        
            return Ok(email);
        }

        public  class signdata
        {
            public string wallet { get; set; }
            public string signature { get; set; }
        }
    }
}
