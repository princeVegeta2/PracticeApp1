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

        public async Task<IList<RepositoryUser>> GetAllUsers()
        {
            try
            {
                List<RepositoryUser> usersLean = await _context.Users
                    .Select(user => new RepositoryUser
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email,
                        IsVerified = user.VerifiedUser != null,
                        FriendsCount = 0, // omitted to avoid loading navigation properties
                        PostTypes = new List<string>(),
                        FriendUsernames = new List<string>(),
                    }).ToListAsync();

                return usersLean;

            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving all users: {ex.Message}");
            }
        }

        public async Task<RepositoryUser> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.Posts)
                    .Include(u => u.Friends).ThenInclude(f => f.Friend)
                    .Include(u => u.FriendOf).ThenInclude(f => f.User)
                    .Include(u => u.Likes).ThenInclude(l => l.Post)
                    .Include(u => u.VerifiedUser)
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    throw new UserNotFoundException($"User with email {email} not found.");
                }

                return PracticeMapper.MapUser(user);
            }
            catch (Exception ex)
            {
                throw new UserNotFoundException($"An error occurred while retrieving the user by email: {ex.Message}", ex);
            }
        }

        public async Task<RepositoryUser> GetUserByUsernameAsync(string username)
        {
           try
            {
                var user = await _context.Users
                    .Include(u => u.Posts)
                    .Include(u => u.Friends).ThenInclude(f => f.Friend)
                    .Include(u => u.FriendOf).ThenInclude(f => f.User)
                    .Include(u => u.Likes).ThenInclude(l => l.Post)
                    .Include(u => u.VerifiedUser)
                    .FirstOrDefaultAsync(u => u.Username == username);

                if (user == null)
                {
                    throw new UserNotFoundException($"User with email {username} not found.");
                }

                return PracticeMapper.MapUser(user);
            }
            catch (Exception ex)
            {
                throw new UserNotFoundException($"An error occurred while retrieving the user by email: {ex.Message}", ex);
            }
        }
    }
}
