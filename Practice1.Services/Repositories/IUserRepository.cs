using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Services.Repositories
{
    public interface IUserRepository
    {   
        /// <summary>
        /// Gets a user by their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        /// Gets a user by their username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<User> GetUserByUsernameAsync(string username);

        /// <summary>
        /// Gets a user by their email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> GetUserByEmailAsync(string email);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        Task<IList<User>> GetAllUsers();

    }
}
