//File Name : IUserDataRepository.cs
//Author    : Mathan Vaithilingam
//Description : User data repository

using VehiclesRepository.DBContext;

namespace VehiclesRepository.DataRepository
{
    /// <summary>
    /// User Data Repository interface
    /// </summary>
    public interface IUserDataRepository
    {
        int AddUser(User user);

        int ValidateUser(User user);

        int UpdateUser(User user);
    }
}
