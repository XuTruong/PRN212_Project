using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Repositories.DTO;

namespace Services
{
    public class AccountService
    {
        AccountRepo _repo;
        public AccountService()
        {
            _repo = new AccountRepo();
        }

        public AccountDTO Login(string username, string password)
        {
            var account = _repo.GetAccount(username, password);
            return account;
        }
    }
}
