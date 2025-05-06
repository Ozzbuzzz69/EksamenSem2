using EksamenProjekt2Sem.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace EksamenProjekt2Sem.Services
{
    public class UserService : GenericDbService<User>
    {
        public List<User> _users; // Overskud fra domain model
        private GenericDbService<User> _dbService; // Overskud fra domain model

        public UserService(UserService userService)
        {
            _dbService = userService;
        }
        public UserService()
        {
            _dbService = new GenericDbService<User>();
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            _users.Add(user);
            _dbService.AddObjectAsync(user);
        }

        /// <summary>
        /// Finds user with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User ReadUser(int id)
        {
            return _users.Find(user => user.Id == id);
        }

        /// <summary>
        /// Reads all users. 
        /// </summary>
        /// <returns></returns>
        public List<User> ReadAllUsers()
        {
            return _users;
        }

        /// <summary>
        /// Updates user with given id. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        public void UpdateUser(int id, User user)
        {
            if (user != null)
            { 
                 foreach (User u in _users)
                 {
                    if (u.Id == id)
                    {
                         u.Name = user.Name;
                         u.Email = user.Email;
                         u.PhoneNumber = user.PhoneNumber;
                         u.Password = user.Password;
                    }
                 }
            }
            _dbService.SaveObjects(_users);
        }

        /// <summary>
        /// Deletes user with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User DeleteUser(int id)
        {
            User userToBeDeleted = null;
            foreach (User u in _users)
            {
                if (u.Id == id)
                {
                    userToBeDeleted = u;
                }
            }
            if (userToBeDeleted != null)
            {
                _users.Remove(userToBeDeleted);
                _dbService.DeleteObjectAsync(userToBeDeleted);
            }
            return userToBeDeleted;
        }

        //public Order Order(List<OrderLine> orderlines)
        //{
        //    // Create order from orderlines
        //    return new Order(); // Placeholder return
        //}
    }
}
