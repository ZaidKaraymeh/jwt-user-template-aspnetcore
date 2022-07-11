using Ticketing.Models;
using Ticketing.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ticketing.Repository
{
    public class UserRepository : IUsers
    {

        readonly DatabaseContext _dbContext = new();
        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                //_dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[User] ON");
                _dbContext.SaveChanges();
                //_dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[User] OFF");

            }
            catch
            {
                throw;
            }
        }

        public bool CheckUser(int id)
        {
            return _dbContext.Users.Any(e => e.Id == id);
        }

        public User DeleteUser(int id)
        {
            try
            {
                User? user = _dbContext.Users.Find(id);

                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    _dbContext.SaveChanges();
                    return user;
                }
                else
                {
                    throw new ArgumentNullException(nameof(id));
                }
            }
            catch
            {
                throw;
            }
        }

        public List<User> GetUserDetails()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch 
            {

                throw;
            }
        }

        public User GetUserDetails(int id)
        {
            try
            {
                User? user = _dbContext.Users.Find(id);
                if (user == null)
                {
                    throw new ArgumentNullException("id");
                }

                return user;
            }
            catch 
            {

                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
