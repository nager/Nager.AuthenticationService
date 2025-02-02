﻿using Nager.AuthenticationService.Abstraction.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Nager.AuthenticationService.Abstraction.Services
{
    /// <summary>
    /// User Management Service Interface
    /// </summary>
    public interface IUserManagementService
    {
        Task<UserInfo[]> QueryAsync(
            int take,
            int skip,
            CancellationToken cancellationToken = default);

        Task<UserInfo?> GetByIdAsync(
            string id,
            CancellationToken cancellationToken = default);

        Task<UserInfo?> GetByEmailAddressAsync(
            string emailAddress,
            CancellationToken cancellationToken = default);

        Task<bool> CreateAsync(
            UserCreateRequest createUserRequest,
            CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(
            string id,
            UserUpdateNameRequest updateUserRequest,
            CancellationToken cancellationToken = default);

        Task<bool> AddRoleAsync(
            string id,
            string roleName,
            CancellationToken cancellationToken = default);

        Task<bool> RemoveRoleAsync(
            string id,
            string roleName,
            CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(
            string id,
            CancellationToken cancellationToken = default);
    }
}
