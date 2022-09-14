using AuthMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthMicroservice.Repository
{
   public interface IAuthRepo<Auth>
    {
        Auth GetRFQCred(Auth cred);
    }
}
