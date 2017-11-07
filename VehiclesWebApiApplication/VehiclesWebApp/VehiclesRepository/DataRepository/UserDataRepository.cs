//File Name : UserDataRepository.cs
//Author    : Mathan Vaithilingam
//Description : User data repository

using System;

namespace VehiclesRepository.DataRepository
{
    /// <summary>
    /// User Data Repository CRUD and Authentication operations
    /// </summary>
    public class UserDataRepository: IUserDataRepository
    {
        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(DBContext.User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Authenticate User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int ValidateUser(DBContext.User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update existing User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUser(DBContext.User user)
        {
            throw new NotImplementedException();
        }
    }
}
