using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConoceTe.Identity.API.Identity.Models
{
    public class TokenModel
    {
        public bool? HasVerifiedEmail { get; set; }
        public bool? TFAEnabled { get; set; }
        public string Token { get; set; }
    }
}
