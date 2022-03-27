using FriendsApplicationApi.Context;
using FriendsApplicationApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsApplicationApi.Services.Implementations
{
    public class UserService : IUsers
    {
        private FriendsDBContext friendsDBContext;

        public UserService(FriendsDBContext a)
        {
            friendsDBContext = a;
        } 
        public void addUser(Users user)
        {
            user.user_id = new Guid();
            friendsDBContext.users.Add(user);
            friendsDBContext.SaveChanges();

        }

        public void DeleteUser(Users person)
        {
            friendsDBContext.users.Remove(person);
            friendsDBContext.SaveChanges();
        }

        public Users getUser(string email)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetFriends(string email)
        {
            Users user = friendsDBContext.users.FromSqlRaw($"select * from users where user_email='" + email + "';").ToArray().First();
            return friendsDBContext.users.FromSqlRaw($"select * from users where user_id=(select friend_id from friends where user_id ='" + user.user_id+ "');").ToList();
        }

        public bool login(string email, string password)
        {
            var person = friendsDBContext.users.FromSqlRaw($"select * from users where user_email='" + email + "' and user_password='" + password + "';");
            if (person.ToArray().Length == 1)
            {
                return true;
            }
            return false;
        }

        public List<Users> search(string search)
        {
            return friendsDBContext.users.FromSqlRaw($"select * from users where user_email='" + search + "' or user_name='" + search + "';").ToList();

        }

        public void makeFriend(string name)
        {
            Users users = friendsDBContext.users.FromSqlRaw($"select * from users where user_name='" + name + "';").ToArray().First();
            Friends friend = new Friends();
            friend.user_id = users.user_id;
            friend.friend_id = users.user_id;
        }
    }
}
