using Microsoft.EntityFrameworkCore;
using Practice1.Services.EntityFramework.Entities;
using Practice1.Services.Repositories;
using Practice1.Services.Exceptions;
using RepositoryUser = Practice1.Services.Repositories.User;
using Practice1.Services.EntityFramework.Helpers;

namespace Practice1.Services.EntityFramework.Repositories
{
    public sealed class UserRepository: IUserRepository
    {
        private readonly PracticeContext _context;
        public UserRepository(PracticeContext context)
        {
            _context = context;
        }

        public async Task<RepositoryUser> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.Posts)
                    .Include(u => u.Friends).ThenInclude(f => f.Friend)
                    .Include(u => u.FriendOf).ThenInclude(f => f.User)
                    .Include(u => u.Likes).ThenInclude(l => l.Post)
                    .Include(u => u.VerifiedUser)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    throw new UserNotFoundException($"User with ID {id} not found.");
                }

                return PracticeMapper.MapUser(user);
            }
            catch (UserNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the user: {ex.Message}", ex);
            }
        }

        public Task<IList<RepositoryUser>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryUser> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryUser> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        Task<RepositoryUser> IUserRepository.GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
