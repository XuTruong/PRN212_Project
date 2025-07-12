using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repositories.DTO;

namespace Repositories
{
    public class AccountRepo
    {
        RoomManagerContext _context;
        public AccountRepo()
        {
            _context = new RoomManagerContext();
        }

        // CRUD
        public AccountDTO GetAccount(string username, string password)
        {
            AccountDTO account = new AccountDTO();
            var finded = _context.Accounts.FirstOrDefault(a => a.Username == username && a.PasswordHash == password);

            if (finded == null)
            {
                return null;
            }

            account.AccountId = finded.AccountId;
            account.Username = finded.Username;
            account.PasswordHash = finded.PasswordHash;
            account.FullName = finded.FullName;
            return account;
        }
    }
}
