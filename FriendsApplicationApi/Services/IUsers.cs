using FriendsApplicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsApplicationApi.Services
{
    public interface IUsers
    {
        List<Users> GetFriends(string email);

        Users getUser(String email);

        void makeFriend(String name);
        bool login(string email, string password);

        void addUser(Users user);

        void DeleteUser(Users person);

        List<Users> search(string email);
    }
}
