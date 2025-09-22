using BNPLService.DTOs;
using System;

namespace BNPLService.Services
{
    public interface IUserClient
    {
        Task<UserDTO?> GetUserByIdAsync(Guid userId);

    }

}