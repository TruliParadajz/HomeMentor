using Shared.Context;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Shared.Services
{
    public interface IUserService
    {
        User Authenticate(string emailAddress, string password);
        User Register(User user, string password);
    }
    public class UserService : IUserService
    {
        private readonly HomeMentorContext _context;
        public UserService(HomeMentorContext context)
        {
            _context = context;
        }

        public User Authenticate(string emailAddress, string password)
        {
            if (string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(password))
            {
                //exception email or password is empty
            }

            var user = _context.Users.SingleOrDefault(user => user.EmailAddress == emailAddress);

            if (user == null)
            {
                //exception no user found
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                //exception wrong username or password
            }

            return user;
        }

        public User Register(User user, string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                //exception password is empty
            }
            if(_context.Users.Any(user => user.EmailAddress == user.EmailAddress))
            {
                //exception user already exists
            }

            (user.PasswordHash, user.PasswordSalt) = CreatePasswordHash(password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (string.IsNullOrEmpty(password))
            {
                //exception password is empty
            }
            if (storedHash.Length != 64)
            {
                //exception
            }
            if (storedSalt.Length != 128)
            {
                //exception
            }

            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password)
        {            
            using(var hmac = new HMACSHA512())
            {
                return (hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key);
            }
        }
    }
}
