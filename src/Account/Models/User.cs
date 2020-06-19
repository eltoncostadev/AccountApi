using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Models
{
    public class User
    {
        int _userId;
        string _name;
        string _phone;
        string _username;
        string _role;
        string _token;
        string _password;
        DateTime _birthDay;
        DateTime _expires;

        public int UserId { get => _userId; set => _userId = value; }
        public string Username { get => _username; set => _username = value; }
        public string Role { get => _role; set => _role = value; }
        public string Password { get => _password; set => _password = value; }
        [NotMapped]
        public string Token { get => _token; set => _token = value; }
        [NotMapped]
        public DateTime Expires { get => _expires; set => _expires = value; }
        public DateTime BirthDay { get => _birthDay; set => _birthDay = value; }
        public string Name { get => _name; set => _name = value; }
        public string Phone { get => _phone; set => _phone = value; }
    }
}
