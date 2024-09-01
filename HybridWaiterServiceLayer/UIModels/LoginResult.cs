using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.UIModels
{
    public class LoginResult
    {
        public bool IsValid { get; set; }
        public string LoginErrorMessage { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;

    }
}
