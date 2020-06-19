using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Models.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        //IEnumerable<User> GetAll();
        Task<IEnumerable<User>> GetAll();
        User Get(int key);
        User Remove(int key);
        void Update(User contact);
    }
}
