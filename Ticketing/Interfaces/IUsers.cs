using Ticketing.Models;

namespace Ticketing.Interfaces
{
    public interface IUsers
    {
        public List<User> GetUserDetails();
        public User GetUserDetails(int id);
        public void AddUser(User employee);
        public void UpdateUser(User employee);
        public User DeleteUser(int id);
        public bool CheckUser(int id);

    }
}
