using AuthMicroservice.Models;
using AuthMicroservice.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthMicroservice.Repository
{
    public class AuthRepo:IAuthRepo<Auth>
    {
        private IAuthProvider<Auth> provider;

        public AuthRepo(IAuthProvider<Auth> _provider)
        {
            provider = _provider;
        }
        public Auth GetRFQCred(Auth cred)
        {
            if (cred == null)
            {
                return null;
            }

            Auth rfq = provider.GetRFQ(cred);

            return rfq;
        }
    }
}
