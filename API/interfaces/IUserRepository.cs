using System;
using System.Security.Claims;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.interfaces;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();

    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByUsernameAsync(string username);

    Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);

    Task<MemberDto?> GetMembersAsync(string username);
    // Task GetUserByUsernameAsync(Claim username);

    
}
