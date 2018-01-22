using Sqr.DC.EF;
using Sqr.DC.EF.Models;
using Sqr.DC.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sqr.DC.BLL.Account
{
    public class BLL_Account:BLL_Base
    {
        protected UserRepository _UserRepository;
        public BLL_Account()
        {
            _UserRepository = new UserRepository();
        }
        public User GetUser(string account)
        {
            return _UserRepository.SingleOrDefault(c => c.Account == account);
        }

        public User ValidAndGetUser(string account,string password)
        {
            var user = _UserRepository.SingleOrDefault(c => c.Account == account);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }
    }
}
