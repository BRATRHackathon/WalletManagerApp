using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WalletManagerApp.Models
{
    public class WalletViewModel
    {
        [Display(Name = "Wallet password")]
        public string WalletPassword { get; set; }

        [Display(Name = "Wallet seed")]
        public string WalletSeed { get; set; }

        [Display(Name = "Wallet address")]
        public string WalletAddress { get; set; }
    }
}