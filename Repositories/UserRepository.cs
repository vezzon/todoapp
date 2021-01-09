using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using toDoApp.DataAccess;
using toDoApp.Models;

namespace toDoApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoItemsContext _db;

        public UserRepository(TodoItemsContext db)
        {
            _db = db;
        }
        public async Task<int> RegisterAsync(User user, string password)
        {
            if (await UserExistsAsync(user.Username))
                return -1;
            
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            return user.Id;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));
            if (user == null)
                return "User doesn't exist";
            return VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) ? "You are logged in" : "Password incorrect";
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _db.Users.AnyAsync(x => x.Username.ToLower().Equals(username.ToLower()));
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                    return false;
            }
            return true;
        }
    }
}