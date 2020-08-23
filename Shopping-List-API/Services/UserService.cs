using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Shopping_List_API.Entities;
using Shopping_List_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Services
{
    public interface IUserService
    {
        Account Authenticate(string username, string password);
        Account GetUserById(int id);
        Account Create(Account account, string password);
        void Update(AccountVM account, string password);
        void Delete(int id);

    }
    public class UserService : IUserService
    {
        private MLDevelopmentContext _db;

        public UserService(MLDevelopmentContext db)
        {
            _db = db;
        }

        public Account Authenticate(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            try
            {
                var account = _db.Accounts.FirstOrDefault(a => a.Email == username);

                if (account == null)
                    return null;
                // check password
                if (!VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
                    return null;
                //authentication successful

                return account;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public Account Create(Account account, string password)
        {
            if (String.IsNullOrEmpty(password))
                throw new ApplicationException("Password is Required");
            if (_db.Accounts.Any(a => a.Email == account.Email))
            {
                throw new ApplicationException($"Username {account.Email} is already taken");
            }

            var entity = new Account();
            entity.Email = account.Email;

            //create password hash
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;

            _db.Accounts.Add(entity);
            _db.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Account GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AccountVM account, string password)
        {
            throw new NotImplementedException();
        }

        // private helper methods
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

    }
}
