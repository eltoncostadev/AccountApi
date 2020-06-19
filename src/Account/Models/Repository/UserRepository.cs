using Account.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private AccountContext _context;
        public UserRepository(AccountContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            var entry = _context.Add(new User());
            _context.Entry<User>(user).State = EntityState.Detached;
            entry.CurrentValues.SetValues(user);
            _context.SaveChanges();
        }

        User IUserRepository.Get(int key)
        {
            throw new NotImplementedException();
        }

        //IEnumerable<User> IUserRepository.GetAll()
        //{
        //    var users = _context.User.ToListAsync<User>();
        //    throw new NotImplementedException();
        //}

        async Task<IEnumerable<User>> IUserRepository.GetAll()
        {
            var users = await _context.User.ToListAsync<User>();
            return users;
        }

        User IUserRepository.Remove(int key)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.Update(User contact)
        {
            throw new NotImplementedException();
        }
    }
}
