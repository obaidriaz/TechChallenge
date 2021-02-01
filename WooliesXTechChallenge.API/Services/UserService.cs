using WooliesXTechChallenge.API.Models;

namespace WooliesXTechChallenge.API.Services
{
    public class UserService: IUserService
    {
        /// <summary>
        /// Get the user information
        /// </summary>
        /// <returns>Basic user information</returns>
        public User GetUser()
        {
            return new User { Name = Constants.Name, Token = Constants.Token };
        }
    }
}
