using AuthMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthMicroservice.Provider
{
   public interface IAuthProvider<Auth>
    {
         List<Auth> GetList();

         Auth GetRFQ(Auth cred);
    }
}
