using Microsoft.AspNetCore.Identity;
using NLayer.Core.DTOs;
using NLayer.Core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IUserService: IService<UserApp>
    {
        Task<IdentityResult> CreateUserAsync(CreateUserDto createUserDto);
        Task<CustomResponseDto<UserDto>> GetUserByNameAsync(string username);
        

    }
}
